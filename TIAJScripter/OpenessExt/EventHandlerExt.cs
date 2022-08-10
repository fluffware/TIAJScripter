using Siemens.Engineering.HmiUnified.UI.Dynamization.Script;
using Siemens.Engineering.HmiUnified.UI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenessExt
{
    public static class EventHandlerExt
    {
        public static void SetAttrs(this HmiButtonEventHandler handler, IEnumerable<KeyValuePair<string, object>> attributes)
        {
            var converted = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> attr in attributes)
            {
                converted.Add(attr.Key, ConvertAttribute.Convert(handler, attr.Key, attr.Value));
            }
            handler.SetAttributes(converted);
        }

        public static void SetAttrs(this HmiScreenEventHandler handler, IEnumerable<KeyValuePair<string, object>> attributes)
        {
            ConvertAttribute.SetAttrs(handler, attributes);
        }

        
       
    }
}
