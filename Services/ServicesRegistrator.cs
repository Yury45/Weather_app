using Microsoft.Extensions.DependencyInjection;
using WPF_MVVM_Template.Services.Interfaces;

namespace WPF_MVVM_Template.Services
{
    internal static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IUserDialog, UserDialogService>()
            .AddTransient<IBotManager, TelegramBotManager>()
            .AddSingleton<ClientsRepository>()
        ;
    }
}