using System;
using WPF_MVVM_Template.Infrastructure.Commands.Base;
using WPF_MVVM_Template.Models.Templates;
using WPF_MVVM_Template.Services;

namespace WPF_MVVM_Template.Infrastructure.Commands
{
    class StartBot : Command
    {
        UserDialogService Dlg = new UserDialogService();
        protected override void Execute(object p)
        {
            try
            {
                var currentConfig = p as UsersConfiguration;

                (p as UsersConfiguration).BotManager = TelegramBotManager.CreateBotManager(p);


                Dlg.ShowInformation("Телеграмм бот успешно запущен.", "Иноформация");
            }
            catch (Exception e)
            {

                Dlg.ShowError("Неверный токен, бот не был запущен", "Предупреждение");
            }
        }
    }
}
