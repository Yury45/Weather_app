﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_MVVM_Template.ViewModels
{
    abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string Property = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(Property);
            return true;
        }
    }
}
