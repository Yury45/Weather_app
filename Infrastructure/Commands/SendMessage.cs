using WPF_MVVM_Template.Infrastructure.Commands.Base;
using WPF_MVVM_Template.Models.Templates;
using WPF_MVVM_Template.Services;
using WPF_MVVM_Template.Services.Interfaces;
using WPF_MVVM_Template.ViewModels;

namespace WPF_MVVM_Template.Infrastructure.Commands
{
    class SendMessage : Command
    {
        protected override void Execute(object parameter)
        {
            var mainWindowViewModel = parameter as MainWindowViewModel;

            var bot = mainWindowViewModel.CurrentConfig.BotManager;

            var answer = mainWindowViewModel.Answer;

            var ChatID = mainWindowViewModel.SelectedClient.Id;
            
            bot.SendMessageAsync(ChatID, answer);

            mainWindowViewModel.Answer = "";
        }
    }
}
