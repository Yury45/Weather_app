using Microsoft.Extensions.DependencyInjection;

namespace WPF_MVVM_Template.ViewModels
{
    internal static class ViewModelsRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
        ;
    }
}
