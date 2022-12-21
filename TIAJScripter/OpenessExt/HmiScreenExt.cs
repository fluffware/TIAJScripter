using Siemens.Engineering.HmiUnified.UI;
using Siemens.Engineering.HmiUnified.UI.Controls;
using Siemens.Engineering.HmiUnified.UI.Screens;
using Siemens.Engineering.HmiUnified.UI.Shapes;
using Siemens.Engineering.HmiUnified.UI.Widgets;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OpenessExt
{
    public static class HmiScreenExt
    {
        public static HmiRectangle CreateRectangle(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiRectangle item = screen.ScreenItems.Create<HmiRectangle>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }

        public static HmiCircle CreateCircle(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiCircle item = screen.ScreenItems.Create<HmiCircle>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }
        public static HmiPolyline CreatePolyline(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiPolyline item = screen.ScreenItems.Create<HmiPolyline>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }

        public static HmiLine CreateLine(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiLine item = screen.ScreenItems.Create<HmiLine>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }

        public static HmiGraphicView CreateGraphicView(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiGraphicView item = screen.ScreenItems.Create<HmiGraphicView>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }
        public static HmiButton CreateButton(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiButton item = screen.ScreenItems.Create<HmiButton>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }

        public static HmiTextBox CreateTextBox(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiTextBox item = screen.ScreenItems.Create<HmiTextBox>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }
        public static HmiIOField CreateIOField(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiIOField item = screen.ScreenItems.Create<HmiIOField>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }

        public static HmiToggleSwitch CreateToggleSwitch(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiToggleSwitch item = screen.ScreenItems.Create<HmiToggleSwitch>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }

        public static HmiListBox CreateListBox(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiListBox item = screen.ScreenItems.Create<HmiListBox>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }

        public static HmiSlider CreateSlider(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiSlider item = screen.ScreenItems.Create<HmiSlider>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }

        public static HmiRadioButtonGroup CreateRadioButtonGroup(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiRadioButtonGroup item = screen.ScreenItems.Create<HmiRadioButtonGroup>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }

        public static HmiCheckBoxGroup CreateCheckBoxGroup(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiCheckBoxGroup item = screen.ScreenItems.Create<HmiCheckBoxGroup>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }
        public static HmiLabel CreateLabel(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiLabel item = screen.ScreenItems.Create<HmiLabel>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }

        public static HmiFaceplateContainer CreateFaceplate(this HmiScreen screen, string name, IEnumerable<KeyValuePair<string, object>> attributes = null)
        {
            HmiFaceplateContainer item = screen.ScreenItems.Create<HmiFaceplateContainer>(name);
            if (attributes != null)
            {
                item.SetAttrs(attributes);
            }
            return item;
        }
    }
}
