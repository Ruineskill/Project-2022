using MaterialDesignThemes.Wpf;
using Presentation.ViewModels.Bases;
using Presentation.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
#nullable disable warnings
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
    /// Interaction logic for DetailDialog.xaml
    /// </summary>
    public partial class DetailDialog : UserControl
    {
        private int  _errors = 0;

        public DetailDialogViewModel Context { get; }
        private DialogSession? _session { get; set; }

        public DetailDialog()
        {
            InitializeComponent();
            Context = App.GetService<DetailDialogViewModel>();
            DataContext = Context;

         
        }

        public void SetContent(ViewModelBase item)
        {
            Context?.SetContent(item);
        }

        public void Close()
        {
            if(_session != null)
            {
                _session.Close();
                _session = null;
            }
            _errors = 0;
        }

        public async Task Show(string parentName)
        {
            await DialogHost.Show(this, parentName, new DialogOpenedEventHandler((sender, args) =>
            {
                _session = args.Session;
            }));

            
        }

        public bool HasErrors()
        {
            return _errors != 0;
        }

        private void Detail_Error(object sender, ValidationErrorEventArgs e)
        {
            if(e.Action == ValidationErrorEventAction.Added)
            {
                _errors++;
            }
            else
            {
                _errors--;
                
            }
        }
    }
}
