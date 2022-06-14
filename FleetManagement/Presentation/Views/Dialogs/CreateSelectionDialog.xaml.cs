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
    /// <summary>
    /// Interaction logic for CreateSelectionDialog.xaml
    /// </summary>
    public partial class CreateSelectionDialog : UserControl
    {
        private DialogSession? Session { get; set; }

        public CreateSelectionDialog()
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

        public async Task<ModelType> Show(string parentName)
        {
            var result = await DialogHost.Show(this, parentName, new DialogOpenedEventHandler((sender, args) =>
            {
                Session = args.Session;
            }));

            if(result != null) return (ModelType)result;
            return ModelType.None;
        }
    }
}
