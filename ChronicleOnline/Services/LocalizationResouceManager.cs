using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Resources;
using Microsoft.Maui.Controls;

namespace ChronicleOnline.Services
{
    public class LocalizationResouceManager : INotifyPropertyChanged
    {
        private static readonly Lazy<LocalizationResouceManager> _instance = new(() => new LocalizationResouceManager());

        public static LocalizationResouceManager Instance => _instance.Value;

        private const string ResourceBaseName = "ChronicleOnline.Resources.Languages.AppResources";

        private readonly ResourceManager _resourceManager;
        private CultureInfo _currentCulture;

        private LocalizationResouceManager()
        {
            _resourceManager = new ResourceManager(ResourceBaseName, typeof(LocalizationResouceManager).Assembly);
            _currentCulture = CultureInfo.CurrentUICulture;
        }

        public string this[string key] =>
            _resourceManager.GetString(key, _currentCulture) ?? $"#{key}#";

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (_currentCulture.Equals(value))
                    return;

                _currentCulture = value;

                CultureInfo.CurrentCulture = value;
                CultureInfo.CurrentUICulture = value;
                CultureInfo.DefaultThreadCurrentCulture = value;
                CultureInfo.DefaultThreadCurrentUICulture = value;
                OnPropertyChanged(string.Empty);

                ApplyFlowDirection(value);
            }
        }

        private static void ApplyFlowDirection(CultureInfo culture)
        {
            var flowDirection = culture.TextInfo.IsRightToLeft
                ? FlowDirection.RightToLeft
                : FlowDirection.LeftToRight;

            if (Application.Current is null)
                return;

            foreach (var window in Application.Current.Windows)
            {
                if (window.Page is not null)
                    window.Page.FlowDirection = flowDirection;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
