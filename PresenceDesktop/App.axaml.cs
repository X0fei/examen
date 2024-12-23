using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using PresenceDesktop.DI;

namespace PresenceDesktop
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCommonServices();
            var services = serviceCollection.BuildServiceProvider();
            var mainWindow = services.GetRequiredService<MainWindow>();
            var presenceWindow = services.GetRequiredService<PresenceWindow>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}