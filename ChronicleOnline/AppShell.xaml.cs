using ChronicleOnline.Services;
using ChronicleOnline.Views;

namespace ChronicleOnline
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LiveStatusPage), typeof(LiveStatusPage));
            Routing.RegisterRoute(nameof(FireReportPage), typeof(FireReportPage));
            Routing.RegisterRoute(nameof(HolidayPage), typeof(HolidayPage));
            Routing.RegisterRoute(nameof(OvertimePage), typeof(OvertimePage));
            Routing.RegisterRoute(nameof(TaFireReportingPage), typeof(TaFireReportingPage));
            Routing.RegisterRoute(nameof(BookHolidayPage), typeof(BookHolidayPage));

            LanguagePicker.ItemsSource = LocalizationHelper.SupportedLanguages;

            var currentCode = LocalizationResouceManager.Instance.CurrentCulture.TwoLetterISOLanguageName;
            LanguagePicker.SelectedItem = LocalizationHelper.SupportedLanguages
                .FirstOrDefault(language => language.CultureCode == currentCode);

        }

        private void OnLanguagePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguagePicker.SelectedItem is LanguageOptions language)
                LocalizationHelper.SetCulture(language.CultureCode);
        }
    }
}