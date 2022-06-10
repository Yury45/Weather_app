using System;
using System.Collections.ObjectModel;
using WPF_MVVM_Template.Models;
using WPF_MVVM_Template.Models.Templates;
using WPF_MVVM_Template.Services.Interfaces;

namespace WPF_MVVM_Template.Services
{
    internal class TelegramBotManager : IBotManager
    {
        public long Id { get; set; }
        private TelegramBot _BotConfiguration;

        public TelegramBot BotConfiguration
        {
            get => _BotConfiguration;
            set => _BotConfiguration = value;
        }

        private TelegramBotManager(String Token, string ApiKey, ObservableCollection<Client> ClientsDB)
        {
            var botConfiguration = new TelegramBot(Token, ApiKey, ClientsDB);

            if (botConfiguration != null && botConfiguration.IsActive)
            {
                BotConfiguration = botConfiguration;
            }
        }

        public static TelegramBotManager CreateBotManager(object p)
        {
            UsersConfiguration userConfiguration = p as UsersConfiguration;

            (p as UsersConfiguration).BotManager = new TelegramBotManager(userConfiguration.Token, userConfiguration.ApiKey, userConfiguration.ClientsDB);

            return (TelegramBotManager)(p as UsersConfiguration).BotManager;
        }

        public ObservableCollection<Client> Clients()
        {
            if (this.BotConfiguration.IsActive)
            {
                return BotConfiguration.ClientsDB;
            }

            return new ObservableCollection<Client>();
        }

        public bool DestroyBotManager()
        {
            if (BotConfiguration.Stop())
            {
                _BotConfiguration = null;
                return true;
            }

            return false;
        }

        public void SendMessageAsync(long ChatID, string Text)
        {
            this.BotConfiguration.Bot.SendTextMessageAsync(ChatID, Text);
        }
    }
}
