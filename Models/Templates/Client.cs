using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace WPF_MVVM_Template.Models
{
    internal enum State
    {
        New,
        None,
        Searching,
        SearchWeather,
        Talking
    }

    internal class Client : IEntity
    {
        #region Состояние клиентского чата

        public State State { get; set; }

        #endregion

        #region ID клиентского чата

        public long Id {get; set; }

        #endregion

        #region _Messages : List<string> - Сообщения пользователя

        /// <summary>Сообщения пользователя поле</summary>
        private ObservableCollection<Message> _Messages = new ObservableCollection<Message>();

        /// <summary>Сообщения пользователя свойство</summary>
        public ObservableCollection<Message> Messages
        {
            get => _Messages;
            set => _Messages = value;
        }

        #endregion

        #region String : Username - Имя клиента

        public string Username { get; set; }

        #endregion

    }
}