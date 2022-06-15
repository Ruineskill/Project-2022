using Presentation.Interfaces;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Presentation.Views.Dialogs;
using Presentation.Enums;

namespace Presentation.Services
{
    public class MessageService : IMessageService
    {
        private readonly ConfirmationDialog _dialog;

        public MessageService()
        {
            _dialog = new ConfirmationDialog();
        }

        public async Task DisplayErrorAsync(string message, DialogHosting Host)
        {

            _dialog.CancelButton.Visibility = Visibility.Hidden;
            _dialog.MsgIcon.Kind = PackIconKind.ErrorOutline;
            await _dialog.Show(message, Host);
        }


        public async Task<bool> DisplayWarningAsync(string message, DialogHosting Host)
        {

            _dialog.CancelButton.Content = "No";
            _dialog.OkButton.Content = "Yes";
            var result = await _dialog.Show(message, Host);

            if(result != null) return (bool)result;
            return false;
        }

    }
}
