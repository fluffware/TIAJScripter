using Siemens.Engineering.HmiUnified.UI.Dynamization;
using Siemens.Engineering.HmiUnified.UI.Dynamization.Script;
using System.Collections.Generic;

namespace OpenessExt
{

    public static class DynamizationsExt
    {
        public static ScriptDynamization CreateScriptDynamization(this DynamizationBaseComposition dyns, string attr_name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            ScriptDynamization dyn = dyns.Create<ScriptDynamization>(attr_name);
            if (attributes != null)
            {
                dyn.SetAttrs(attributes);
            }
            return dyn;
        }

        public static TagDynamization CreateTagDynamization(this DynamizationBaseComposition dyns, string attr_name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            TagDynamization dyn = dyns.Create<TagDynamization>(attr_name);
            if (attributes != null)
            {
                dyn.SetAttrs(attributes);
            }
            return dyn;
        }

        public static void SetAttrs(this DynamizationBase dyn, IEnumerable<KeyValuePair<string, object>> attributes)
        {
            var converted = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> attr in attributes)
            {
                  
                converted.Add(attr.Key, ConvertAttribute.Convert(dyn, attr.Key, attr.Value));
            }
            dyn.SetAttributes(converted);
        }

    }
}
