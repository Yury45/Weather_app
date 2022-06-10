using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_Template.Services.Interfaces;
using WPF_MVVM_Template.ViewModels;

namespace WPF_MVVM_Template.Models.Templates
{
    class AnswerTemplate
    {
        public IBotManager? BotManager { get; set; }

        public string? Answer { get; set; }

        public long? ChatID { get; set; }

        public AnswerTemplate(MainWindowViewModel MainWindowViewModel)
        {
            this.BotManager = MainWindowViewModel.BotManager;
            this.Answer = MainWindowViewModel.Answer;
            this.ChatID = MainWindowViewModel.SelectedClient.Id;
        }
    }
}
