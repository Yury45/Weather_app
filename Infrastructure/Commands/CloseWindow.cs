﻿using System.Windows;
using WPF_MVVM_Template.Infrastructure.Commands.Base;

namespace WPF_MVVM_Template.Infrastructure.Commands
{
    internal class CloseWindow : Command
    {
        protected override void Execute(object parameter) => (parameter as Window ?? App.FocusedWindow ?? App.ActivedWindow)?.Close();
    }
}
