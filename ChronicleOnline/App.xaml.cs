using ChronicleOnline.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChronicleOnline
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LocalizationHelper.ApplySavedCulture();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}