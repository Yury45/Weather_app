using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Windows;
using WPF_MVVM_Template.Services;
using WPF_MVVM_Template.ViewModels;

namespace WPF_MVVM_Template
{
    public partial class App
    {
        public static Window FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);
        public static Window ActivedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

        private static IHost __Host;

        public static IHost Host => __Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddServices();
            services.AddViewModels();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            base.OnStartup(e);

            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            using (Host) await Host.StopAsync();
        }
    }
}
