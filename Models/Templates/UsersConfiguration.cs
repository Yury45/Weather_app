using System.Collections.ObjectModel;
using WPF_MVVM_Template.Services.Interfaces;

namespace WPF_MVVM_Template.Models.Templates
{
    internal class UsersConfiguration
    {
        public UsersConfiguration(bool? IsChecked, string? Token, string? WeatherKeyAPI, IBotManager? BotManager, ObservableCollection<Client>? Clients)
        {
            this.IsActive = IsChecked;
            this.Token = Token;
            this.ApiKey = WeatherKeyAPI;
            this.BotManager = BotManager;
            this.ClientsDB = Clients;
        }
        public bool? IsActive { get; set; }

        public string? Token;

        public string? ApiKey;

        public IBotManager? BotManager;

        public ObservableCollection<Client>? ClientsDB { get; set; }
    }
}