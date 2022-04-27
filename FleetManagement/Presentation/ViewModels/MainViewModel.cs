
using Presentation.Interfaces;

namespace Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;

        public ViewModelBase CurrentViewModel => _navigationService.CurrentViewModel;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.OnViewModelChanged(CurrentViewModelChanged);
        }

        private void CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
