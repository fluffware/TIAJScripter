using Siemens.Engineering.HmiUnified.UI.Dynamization.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenessExt
{
    public static class TriggerExt
    {
        public static void SetAttrs(this Trigger trigger, IEnumerable<KeyValuePair<string, object>> attributes)
        {
            ConvertAttribute.SetAttrs(trigger, attributes);
        }
    }
}
