#nullable disable
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.ViewModels.Bases;

namespace Presentation.ViewModels
{
    public class FleetViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;

        private string _search = string.Empty;

        public string Search
        {
            get => _search;
            set => SetProperty(ref _search, value);

        }


        private ObservableCollection<TabViewModelBase> _tabs;
        public ObservableCollection<TabViewModelBase> Tabs { get => _tabs; set => _tabs = value; }

        private TabViewModelBase _selectedTab;
        public TabViewModelBase SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }


        public FleetViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            SignOutCommand = new RelayCommand(SignOutHandler);

            _tabs = new()
            {
                App.Current.Services.GetService<CarListingViewModel>(),
                App.Current.Services.GetService<PersonListingViewModel>(),
                App.Current.Services.GetService<FuelCardListingViewModel>(),
            };


            _selectedTab = _tabs.First();


           
            //EditItemCommand = new RelayCommand(EditItemHandler);
            //DeleteItemCommand = new RelayCommand(DeleteItemHandler);
        }



        public ICommand SignOutCommand { get; }
        private void SignOutHandler()
        {
            var apiService = App.Current.Services.GetService<IApiSecurityService>();
            apiService.SignOut();

            _navigationService.Navigate(App.Current.Services.GetService<LogInViewModel>());
           
        }

     

        //public ICommand EditItemCommand { get; }
        //private void EditItemHandler()
        //{

        //}

        //public ICommand DeleteItemCommand { get; }
        //private void DeleteItemHandler()
        //{

        //}
    }
}
