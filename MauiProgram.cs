using ksalazarS5Online.Utils;
using Microsoft.Extensions.Logging;

namespace ksalazarS5Online
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string dbRuta = FileAccessHelper.GetFolderPath("uisrael.db3");
            builder.Services.AddSingleton<personaRepo>
                (s=>ActivatorUtilities.CreateInstance<personaRepo>(s, dbRuta));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
