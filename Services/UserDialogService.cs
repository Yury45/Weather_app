using System.Windows;
using WPF_MVVM_Template.Services.Interfaces;
namespace WPF_MVVM_Template.Services
{
    internal class UserDialogService : IUserDialog
    {
        public void ShowInformation(string Information, string Caption) => MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);

        public void ShowError(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);

        public bool Confirm(string Message, string Caption, bool Exclcamation = false) =>
            MessageBox.Show(Message, Caption, MessageBoxButton.YesNo, Exclcamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question) == MessageBoxResult.Yes;

    }
}
