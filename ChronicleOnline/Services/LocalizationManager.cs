using System;
using ChronicleOnline.Resources.Languages;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Globalization;

namespace ChronicleOnline.Services
{
    public class LocalizationManager : INotifyPropertyChanged
    {
        public static readonly LocalizationManager Instance = new();
        public static event Action? CultureChanged;
        private LocalizationManager() { }

        public event PropertyChangedEventHandler? PropertyChanged;

        //public string this[string key] =>
        //    AppResources.ResourceManager.GetString(key, AppResources.Culture) ?? key;

        public string this[string key]
        {
            get
            {
                var val = AppResources.ResourceManager.GetString(key, AppResources.Culture);
                System.Diagnostics.Debug.WriteLine($"[Localize] key='{key}' value='{val}'");
                return val ?? $"[{key}]";
            }
        }

        public CultureInfo CurrentCulture => AppResources.Culture ?? CultureInfo.CurrentUICulture;

        public void SetCulture(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            AppResources.Culture = culture;
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;



            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
            CultureChanged?.Invoke();
        }

        public bool IsRtl => CurrentCulture.TextInfo.IsRightToLeft;
    }
}
