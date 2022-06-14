using Presentation.Interfaces;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Presentation.Views.Dialogs;

namespace Presentation.Services
{
    public class MessageService : IMessageService
    {
        public async Task DisplayErrorAsync(string message)
        {
            var dialog = new ConfirmationDialog(message);
            dialog.CancelButton.Visibility = Visibility.Hidden;
            dialog.MsgIcon.Kind = PackIconKind.ErrorOutline;
            await DialogHost.Show(dialog, "MainWinDialog");
        }


        public async Task<bool> DisplayWarningAsync(string message, string hostName)
        {
            var dialog = new ConfirmationDialog(message);
            dialog.CancelButton.Content = "No";
            dialog.OkButton.Content = "Yes";
            var result = await DialogHost.Show(dialog, hostName);

            if(result != null) return (bool)result;
            return false;
        }

    }
}
