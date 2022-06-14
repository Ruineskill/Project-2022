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
    internal class DetailNavigationService : IDetailNavigationService
    {
        private ViewModelBase _currentViewModel;
        private ViewModelBase? _previousViewModel = null;

        public ViewModelBase CurrentViewModel { get => _currentViewModel; }

        public event Action CurrentViewModelChanged;

        public void Navigate(ViewModelBase viewModel)
        {
            _previousViewModel = _currentViewModel;
            _currentViewModel = viewModel;
            CurrentViewModelChanged?.Invoke();
        }

        public void OnViewModelChanged(Action currentViewModelChanged)
        {
            CurrentViewModelChanged += currentViewModelChanged;
        }

        public void GoBack()
        {
            _currentViewModel = _previousViewModel;
            _previousViewModel = null;
            CurrentViewModelChanged?.Invoke();
        }
    }
}
