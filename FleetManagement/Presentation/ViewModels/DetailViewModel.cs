#nullable disable warnings
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Presentation.Interfaces;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        private readonly IDetailNavigationService _detailNavigationService;
        private readonly IDetailDialogService _detailDialogService;
        public ViewModelBase CurrentViewModel => _detailNavigationService.CurrentViewModel;


        public DetailViewModel(IDetailNavigationService detailNavigationService, IDetailDialogService detailDialogService)
        {
            _detailNavigationService = detailNavigationService;
            
            _detailDialogService = detailDialogService;

            _detailNavigationService.OnViewModelChanged(CurrentViewModelChanged);          

            SaveCommand = new RelayCommand(SaveCommandHandler);
        }


        private void CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public ICommand SaveCommand { get; }

        void SaveCommandHandler()
        {
            _detailDialogService.Close();
            
        }

    }
}
