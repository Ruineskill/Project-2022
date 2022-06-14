#nullable disable warnings
using Presentation;
using Presentation.Interfaces.Navigation;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Services.Navigation
{
    public class MainNavigationService : INavigationService
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel { get => _currentViewModel; }

        public event Action CurrentViewModelChanged;

        public void Navigate(ViewModelBase viewModel)
        {
            _currentViewModel = viewModel;
            CurrentViewModelChanged?.Invoke();
        }

        public void OnViewModelChanged(Action currentViewModelChanged)
        {
            CurrentViewModelChanged += currentViewModelChanged;
        }
    }
}
