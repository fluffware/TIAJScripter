using Siemens.Engineering.SW.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TIAJScripter.OpenessExt
{
    public static class PlcBlockExt
    {
        public static XmlDocument ExportXML(this PlcBlock block)
        {
            return TIAutils.ExportPlcBlockXML(block);
        }
    }
}
