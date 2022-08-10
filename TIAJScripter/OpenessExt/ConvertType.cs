using Jint.Runtime.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIAJScripter.OpenessExt
{
    internal class ConvertType : ITypeConverter
    {
        readonly ITypeConverter defaultConverter;
        public ConvertType(ITypeConverter defaultConverter)
        {
            this.defaultConverter = defaultConverter;
        }
        public static object ConvertOpeness(object value, Type type)
        {

            if (type == typeof(string) && value is string str)
            {
                return str;
            }
            else
            if (type == typeof(object) && value is string obj_str)
            {
                return (object)obj_str;
            }
            else
            if (type == typeof(System.Drawing.Color) && value is Object[] obj_array)
            {
                Int32 a = 255;
                Int32 r;
                Int32 g;
                Int32 b;
                if (obj_array.Count() == 3)
                {
                    try
                    {
                        r = System.Convert.ToInt32(obj_array[0]);
                        g = System.Convert.ToInt32(obj_array[1]);
                        b = System.Convert.ToInt32(obj_array[2]);

                    }
                    catch
                    {
                        throw new Exception("Color arrays may only contain integers");
                    }
                }
                else if (obj_array.Count() == 4)
                {
                    try
                    {
                        a = System.Convert.ToInt32(obj_array[0]);
                        r = System.Convert.ToInt32(obj_array[1]);
                        g = System.Convert.ToInt32(obj_array[2]);
                        b = System.Convert.ToInt32(obj_array[3]);
                    }
                    catch
                    {
                        throw new Exception("Color arrays may only contain integers");
                    }
                }
                else
                {
                    throw new Exception("Color arrays must be of length 3 or 4");
                }
                return System.Drawing.Color.FromArgb(a, r, g, b);
            }
            else if (type.IsEnum && value is string enum_str)
            {
                try
                {
                    object enumeration = Enum.Parse(type, enum_str);
                    return enumeration;
                }
                catch (ArgumentException)
                {
                    string[] enum_names = type.GetEnumNames();
                    throw new Exception("Value must be one of " + string.Join(", ", enum_names));
                }
            }
            else if (type.IsAssignableFrom(typeof(List<string>)) && value is Object[] str_array)
            {
                List<string> list = new List<string>();
                foreach (object str_item in str_array)
                {
                    list.Add(str_item.ToString());
                }
                return list;
            }
            return null;
        }
        public object Convert(object value, Type type, IFormatProvider formatProvider)
        {
            object converted = ConvertOpeness(value, type);
            if (converted != null) return converted;
            return defaultConverter.Convert(value, type, formatProvider);
        }

        public bool TryConvert(object value, Type type, IFormatProvider formatProvider, out object converted)
        {
            try
            {
                converted = ConvertOpeness(value, type);
                if (converted != null) return true;
            }
            catch { }

            return defaultConverter.TryConvert(value, type, formatProvider, out converted);
        }
    }

}

