using ChronicleOnline.Services;
using ChronicleOnline.Views;

namespace ChronicleOnline
{
    public partial class AppShell : Shell
    {
        private static readonly string[] CultureCodes = new string[] { "en", "ur", "fr" };

        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LiveStatusPage), typeof(LiveStatusPage));
            Routing.RegisterRoute(nameof(FireReportPage), typeof(FireReportPage));
            Routing.RegisterRoute(nameof(HolidayPage), typeof(HolidayPage));
            Routing.RegisterRoute(nameof(OvertimePage), typeof(OvertimePage));
            Routing.RegisterRoute(nameof(TaFireReportingPage), typeof(TaFireReportingPage));
            Routing.RegisterRoute(nameof(BookHolidayPage), typeof(BookHolidayPage));

            LocalizationManager.CultureChanged += OnCultureChanged;
        }

        private void OnCultureChanged()
        {
            MainThread.BeginInvokeOnMainThread(UpdateFlyoutTitles);
        }
        private void UpdateFlyoutTitles()
        {
            var lm = LocalizationManager.Instance;

            BrandNamePrimary.Text = lm["Brand_Primary"];
            BrandNameAccent.Text = lm["Brand_Accent"];

            if (Items.Count > 0 && Items[0] is FlyoutItem home)
            {
                if (home.Items.Count > 0 && home.Items[0].Items.Count > 0)
                    home.Items[0].Items[0].Title = lm["Nav_Home"];
                if (home.Items.Count > 1 && home.Items[1].Items.Count > 0)
                    home.Items[1].Items[0].Title = lm["Nav_LiveStatus"];
                if (home.Items.Count > 2 && home.Items[2].Items.Count > 0)
                    home.Items[2].Items[0].Title = lm["Nav_FireReport"];
                if (home.Items.Count > 3 && home.Items[3].Items.Count > 0)
                    home.Items[3].Items[0].Title = lm["Nav_Holiday"];
                if (home.Items.Count > 4 && home.Items[4].Items.Count > 0)
                    home.Items[4].Items[0].Title = lm["Nav_Overtime"];
            }

            if (Items.Count > 1 && Items[1] is FlyoutItem bookHoliday)
                bookHoliday.Title = lm["Nav_BookHoliday"];

            if (Items.Count > 2 && Items[2] is FlyoutItem taFire)
                taFire.Title = lm["Nav_TaFireReporting"];

            LogoutButton.Text = lm["Nav_Logout"];
            LanguagePicker.Title = lm["Nav_Language"];
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            if (picker.SelectedIndex < 0) return;

            var code = CultureCodes[picker.SelectedIndex];
            LocalizationManager.Instance.SetCulture(code); 

            FlowDirection = LocalizationManager.Instance.IsRtl
                ? FlowDirection.RightToLeft
                : FlowDirection.LeftToRight;
        }
    }
}