using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces.Navigation
{
    public interface INavigationService
    {
        ViewModelBase CurrentViewModel { get; }
        void Navigate(ViewModelBase viewModel);
        void OnViewModelChanged(Action currentViewModelChanged);
    }
}
