using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using WPF_MVVM_Template.Models.Validators;


namespace WPF_MVVM_Template.Models
{

    internal class TelegramBot
    {
        private ObservableCollection<Client> _ClientsDB;

        public ObservableCollection<Client> ClientsDB
        {
            get => _ClientsDB;
            set
            {
                _ClientsDB = value;
            }
        }

        private HttpClient hc = new HttpClient();

        #region _IsActive : bool - Состояние бота

        /// <summary>Состояние бота поле</summary>
        private bool _IsActive = false;

        /// <summary>Состояние бота свойство</summary>
        public bool IsActive
        {
            get => _IsActive;
            set { _IsActive = value; }
        }

        #endregion

        #region _Bot : TelegramBotClient - Бот-клиент

        /// <summary>Бот поле</summary>
        private TelegramBotClient _Bot;

        /// <summary>Бот свойство</summary>
        public TelegramBotClient Bot
        {
            get => _Bot;
            set
            {
                if (Equals(_Bot, value)) return;
                _Bot = value;
            }
        }

        #endregion

        #region Конструктор объекта класса TelegramBot
        /// <summary>При создании экземпляра класса проверяются валидность Token.</summary>
        public TelegramBot(string Token, string ApiKey, ObservableCollection<Client> ClientsDB)
        {
            var bot = new TelegramBotClient(Token);


            if (TryConnection(bot, ApiKey))
            {
                Bot = bot;

                this.ClientsDB = ClientsDB;

                IsActive = true;

                WeatherHook.ApiKey = ApiKey;

                bot.StartReceiving();

                bot.OnMessage += OnMessegeHandler;

            }
            else throw new Exception("Неверный токен");
        }


        #endregion


        private async void OnMessegeHandler(object P, MessageEventArgs Arg)
        {
            App.Current.Dispatcher.Invoke((Action)delegate { Logs(Arg.Message); });
            SendAnswerAsync(Arg.Message);

        }

        private async Task SendAnswerAsync(Message Message)
        {
            await StateValidator.Validate(this, Message);
        }

        private bool TryConnection(TelegramBotClient Bot, string API)
        {
            try
            {
                return Bot.GetMeAsync().Result.IsBot;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Stop()
        {
            this.Bot.StopReceiving();

            this.Bot = null;

            IsActive = false;

            return true;
        }

        public void Logs(Message Message)
        {
            var client = ClientsDB.Where(i => i.Id == Message.Chat.Id).FirstOrDefault();

            if (client != null)
            {
                var index = ClientsDB.IndexOf(client);
                ClientsDB[index].Messages.Add(Message);
                return;
            }
            else
            {
                Client currentClient = new Client()
                {
                    Username = Message.Chat.Username,
                    Id = Message.Chat.Id,
                    State = State.New,
                    Messages = new ObservableCollection<Message>()
                    {
                        Message,
                    }
                };

                ClientsDB.Add(currentClient);

            }
            return;
        }
    }
}
