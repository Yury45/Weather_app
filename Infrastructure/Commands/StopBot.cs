
using WPF_MVVM_Template.Infrastructure.Commands.Base;
using WPF_MVVM_Template.Models.Templates;
using WPF_MVVM_Template.Services;
using WPF_MVVM_Template.Services.Interfaces;

namespace WPF_MVVM_Template.Infrastructure.Commands
{
    class StopBot : Command
    {
        protected override void Execute(object p)
        {
            UserDialogService dlg = new UserDialogService();
            if ((p as UsersConfiguration).BotManager == null)
            {
                dlg.ShowInformation("Нет активного бота!","Уведомление");
                return;
            }
            if ((p as UsersConfiguration).BotManager.DestroyBotManager()) dlg.ShowInformation("Бот был отключен!","Иноформация");
            else dlg.ShowError("Упс... Отключение бота не было выполнено!", "Ошибка");
        }
    }
}
