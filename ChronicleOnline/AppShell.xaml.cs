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
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(BookHolidayPage), typeof(BookHolidayPage));
        }
    }
}
