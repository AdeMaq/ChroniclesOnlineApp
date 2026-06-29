using System;
using ChronicleOnline.Services;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ChronicleOnline.Services
{
    public class LocalizationHelper
    {
        private const string LanguagePreferenceKey = "AppLanguage";
        private const string DefaultCultureCode = "en";

        public static List<LanguageOptions> SupportedLanguages { get; } = new()
        {
            new LanguageOptions { DisplayName = "English",  CultureCode = "en" },
            new LanguageOptions { DisplayName = "اردو",      CultureCode = "ur" },
            new LanguageOptions { DisplayName = "Français",  CultureCode = "fr" },
        };

        public static void ApplySavedCulture()
        {
            var savedCode = Preferences.Default.Get(LanguagePreferenceKey, DefaultCultureCode);
            SetCulture(savedCode);
        }

        public static void SetCulture(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            LocalizationResouceManager.Instance.CurrentCulture = culture;
            Preferences.Default.Set(LanguagePreferenceKey, cultureCode);
        }
    }
}
