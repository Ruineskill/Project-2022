using Microsoft.Toolkit.Mvvm.Input;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels.Bases
{
    public abstract class TabViewModelBase : ViewModelBase
    {
        public abstract string Name { get; set; }

        public abstract ValidatedViewModelBase? SelectedItem { get; set; }

      

    }
}
