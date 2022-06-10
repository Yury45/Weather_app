using Microsoft.Extensions.DependencyInjection;

namespace WPF_MVVM_Template.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();

    }
}
