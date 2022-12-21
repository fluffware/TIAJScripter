using Siemens.Engineering;
using System;
using System.Globalization;

namespace TIAJScripter.OpenessExt
{
    public static class MultilingualTextExt
    {
        public static Project Project = null;
        public static string GetText(this MultilingualText self, string culture = null)
        {
            if (Project == null) throw new Exception("No project active");
            var lang = Project.LanguageSettings.Languages.Find(new CultureInfo(culture));
            var item = self.Items.Find(lang);
            return (item != null) ? item.Text : "<No text>";
        }

        public static void SetText(this MultilingualText self, string culture, string value)
        {
            if (Project == null) throw new Exception("No project active");
            var lang = Project.LanguageSettings.Languages.Find(new CultureInfo(culture));
            var item = self.Items.Find(lang);
            if (item == null) return;
            self.Items.Find(lang).Text = value;
        }
    }
}
