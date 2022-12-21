using Siemens.Engineering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TIAJScripter.OpenessExt;

namespace OpenessExt
{
    static public class ConvertAttribute
    {

        public static void SetAttrs(dynamic item, IEnumerable<KeyValuePair<string, object>> attributes)
        {
            var converted = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> attr in attributes)
            {
                PropertyInfo prop = item.GetType().GetProperty(attr.Key);
                if (prop == null)
                {
                    PropertyInfo[] properties = item.GetType().GetProperties();
                    string prop_names = string.Join(", ", properties.Select(p => p.Name));
                    
                    throw new Exception("No attribute matching " + attr.Key + ", try one of "+prop_names);
                }
                else
                {
                    Type prop_type = prop.PropertyType;
                    if (prop_type == typeof(MultilingualText) && attr.Value is string str_value)
                    {
                        MultilingualText mtext = (MultilingualText)prop.GetValue(item);
                        foreach (MultilingualTextItem titem in mtext.Items)
                        {
                            titem.Text = str_value;
                        }
                    }
                    else
                    {
                        converted.Add(attr.Key, ConvertAttribute.Convert(item, attr.Key, attr.Value));
                    }
                }
            }
            item.SetAttributes(converted);
        }
        static public object Convert(object obj, string name, object value)
        {
            PropertyInfo prop = obj.GetType().GetProperty(name);
            if (prop == null)
            {
                return value;
            }
            else
            {

                Type prop_type = prop.PropertyType;
                if (prop_type.IsPrimitive && value is IConvertible)
                {
                    return System.Convert.ChangeType(value, prop.PropertyType);
                }
                else
                {
                    object converted = ConvertType.ConvertOpeness(value, prop_type);
                    if (converted == null)
                    {
                        throw new Exception("Can't convert to proper type for attribute '" + name + "'");
                    }
                    return converted;
                }
            }
        }
    }
}



