#nullable disable warnings
using MaterialDesignThemes.Wpf;
using Presentation.ViewModels.Dialogs;
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
    /// <summary>
    /// Interaction logic for SelectorDialog.xaml
    /// </summary>
    public partial class SelectorDialog : UserControl
    {
        public SelectorDialogViewModel Context { get; }

        private DialogSession? Session { get; set; }

        public SelectorDialog()
        {
            InitializeComponent();
            Context = new SelectorDialogViewModel();
            DataContext = Context;

           

        }
      
        public void Close()
        {
            if(Session != null)
            {
                Session.Close();
                Session = null;
            }  
        }

        public async Task Show(string parentName)
        {
            await DialogHost.Show(this, parentName, new DialogOpenedEventHandler((sender, args) =>
            {
                Session = args.Session;
            }));
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
               Context.SelectCommand.Execute(null);
            }
        }
    }
}
