using MaterialDesignThemes.Wpf;
using Presentation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation.Views.Dialogs
{
    public partial class ConfirmationDialog : UserControl
    {
        private DialogSession? Session { get; set; }

        public ConfirmationDialog()
        {
            InitializeComponent();
        }

        public void Close()
        {
            if(Session != null)
            {
                Session.Close();
                Session = null;
            }
        }

        public async Task<object?> Show(string message, DialogHosting Host)
        {
            Msg.Text = message;
            return await DialogHost.Show(this, Host.ToString(), new DialogOpenedEventHandler((sender, args) =>
             {
                 Session = args.Session;
             }));
        }
    }
}
