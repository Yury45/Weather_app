using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using WPF_MVVM_Template.Models;

namespace WPF_MVVM_Template.Services.Interfaces
{
    internal interface IBotManager : IEntity
    {
        ObservableCollection<Client> Clients();
        bool DestroyBotManager();
        void SendMessageAsync(long Id, string Text);

    }
}
