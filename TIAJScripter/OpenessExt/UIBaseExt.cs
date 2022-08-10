using Siemens.Engineering;
using Siemens.Engineering.HmiUnified.UI;
using Siemens.Engineering.HmiUnified.UI.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenessExt
{
    public static class UIBaseExt
    {
        public static void SetAttrs(this UIBase item, IEnumerable<KeyValuePair<string, object>> attributes)
        {
            ConvertAttribute.SetAttrs(item, attributes);
        }
    }
}
