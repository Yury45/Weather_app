﻿using System;

using WPF_MVVM_Template.Infrastructure.Commands.Base;

namespace WPF_MVVM_Template.Infrastructure.Commands
{
    internal class LambdaCommandAsync : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommandAsync(Action Execute, Func<bool> CanExecute = null)
            : this(p => Execute(), CanExecute is null ? (Func<object, bool>)null : p => CanExecute())
        {

        }

        public LambdaCommandAsync(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }
        protected override void Execute(object parameter) => _Execute(parameter);

        protected override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
    }
}
