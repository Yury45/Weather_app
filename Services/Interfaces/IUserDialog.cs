namespace WPF_MVVM_Template.Services.Interfaces
{
    internal interface IUserDialog
    {

        void ShowInformation(string Information, string Caption);

        void ShowWarning(string Message, string Caption);

        void ShowError(string Message, string Caption);

        bool Confirm(string Message, string Caption, bool Exclcamation = false);
    }
}
