using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ChronicleOnline.Resources.Languages;
using ChronicleOnline.Services;
using Microsoft.Maui.Handlers;

namespace ChronicleOnline
{
    public static class MauiProgram
    {

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
                PickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
                {
#if ANDROID
                    handler.PlatformView.Background = null;
#endif
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
