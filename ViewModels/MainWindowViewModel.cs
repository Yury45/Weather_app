using System.Collections.ObjectModel;
using System.Windows.Data;
using Telegram.Bot.Types;
using WPF_MVVM_Template.Models;
using WPF_MVVM_Template.Models.Templates;
using WPF_MVVM_Template.Services.Interfaces;


namespace WPF_MVVM_Template.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        #region _Text : string - Название главного окна

        /// <summary>Поле под название приложения</summary>
        private string _Title = "Application";

        /// <summary>Свойство названия приложения</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region _State : string - Статус приложения

        /// <summary>Статус приложения поле</summary>
        private string _State;

        /// <summary>Статус приложения свойство</summary>
        public string State
        {
            get => _State;
            set => Set(ref _State, value);
        }

        #endregion

        #region _Answer : string - Сообщение для клиента

        /// <summary>Сообщение для клиента поле</summary>
        private string _Answer;

        /// <summary>Сообщение для клиента свойство</summary>
        public string Answer
        {
            get => _Answer;
            set => Set(ref _Answer, value);
        }

        #endregion

        private static object _lock = new object();

        public MainWindowViewModel()
        {
            _Clients = new ObservableCollection<Client>();
            BindingOperations.EnableCollectionSynchronization(_Clients, _lock);

            this.CurrentConfig = new UsersConfiguration(IsChecked, Token, WeatherKeyAPI, BotManager, Clients);
        }

        #region _SelectedClient : Client - Выбранный клиент

        /// <summary>Выбранный клиент поле</summary>
        private Client? _SelectedClient;

        /// <summary>Выбранный клиент свойство</summary>
        public Client? SelectedClient
        {
            get => _SelectedClient;
            set => Set(ref _SelectedClient, value);
        }

        #endregion

        #region _SelectedMessage : Message - Выбранное сообщение

        /// <summary>Выбранное сообщение поле</summary>
        private Message _SelectedMessage;

        /// <summary>Выбранное сообщение свойство</summary>
        public Message SelectedMessage
        {
            get => _SelectedMessage;
            set => Set(ref _SelectedMessage, value);
        }

        #endregion

        #region Настройки бота : Параметры текущей сборки (Token, ApiKey, BotManager,ClientsDB, IsRemember)

        #region _CurrentConfiguration : UserConfiguration - Настройки текущего бота

        private UsersConfiguration _CurrentConfig;
        public UsersConfiguration CurrentConfig
        {
            get => _CurrentConfig;
            set => Set(ref _CurrentConfig, value);
        }

        #endregion

        #region _Clients : ObservableCollection<Client> - Данные клиентов 

        private ObservableCollection<Client> _Clients;
        public ObservableCollection<Client> Clients
        {
            get => _Clients;
            set => Set(ref _Clients, value);
        }

        #endregion

        #region IBotManager - BotManager

        /// <summary>Бот свойство</summary>
        private IBotManager? _BotManager;
        public IBotManager? BotManager
        {
            get => _BotManager;
            set => _BotManager = value;
        }

        #endregion

        #region Token : string - Token

        /// <summary>Token  свойство</summary>
        ///Token -  "5081119124:AAGXGoC_Qbi8ySJSVtHbPjMdNA27Tbwr8oo"
        private string? _Token;
        public string? Token
        {
            get => _Token;
            set => Set(ref this.CurrentConfig.Token, value);
        }

        #endregion

        #region WeatherKeyAPI : string - API ключ от сайта погоды

        /// <summary>API ключ от сайта погоды свойство</summary>
        ///APIKey - bec164245ddbee25d0282f7ef54259a9
        private string? _WeatherKeyAPI;
        public string? WeatherKeyAPI
        {
            get => _WeatherKeyAPI;
            set => Set(ref this.CurrentConfig.ApiKey, value);
        }

        #endregion

        #region IsChecked : bool - Запоминание выбора

        /// <summary>Запоминание выбора свойство</summary>
        private bool? _IsChecked;
        public bool? IsChecked
        {
            get => _IsChecked;
            set => Set(ref _IsChecked, value);
        }

        #endregion

        #endregion


    }
}

