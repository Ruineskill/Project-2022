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
using Presentation.Mediators;
using Presentation.Interfaces.ApiHttp;
using Presentation.Interfaces.Navigation;
using Presentation.ViewModels.Listing;
using Presentation.Enums;

namespace Presentation.ViewModels
{
    public class FleetViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;

        private readonly IDetailService _detailService;

        private string _search = string.Empty;

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                SelectedTab.Filter(_search);
            }

        }


        private ObservableCollection<TabViewModelBase> _tabs;
        public ObservableCollection<TabViewModelBase> Tabs { get => _tabs; set => _tabs = value; }

        private TabViewModelBase _selectedTab;
        public TabViewModelBase SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }


        public FleetViewModel(INavigationService navigationService, IDetailService detailService)
        {
            _navigationService = navigationService;
            _detailService = detailService;

            SignOutCommand = new RelayCommand(SignOutHandler);

            _tabs = new()
            {
                App.Current.Services.GetService<PersonListingViewModel>(),
                App.Current.Services.GetService<CarListingViewModel>(),
                App.Current.Services.GetService<FuelCardListingViewModel>(),
            };


            _selectedTab = _tabs.First();



            OpenItemCommand = new AsyncRelayCommand(OpenItemHandler);
            DeleteItemCommand = new AsyncRelayCommand(DeleteItemHandler);
            CreateItemCommand = new AsyncRelayCommand<bool>(CreateItemHandler);

        }



        public ICommand SignOutCommand { get; }
        private void SignOutHandler()
        {
            var apiService = App.Current.Services.GetService<IApiSecurityService>();
            apiService.SignOut();

            _navigationService.Navigate(App.Current.Services.GetService<LogInViewModel>());

        }



        public ICommand OpenItemCommand { get; }
        private async Task OpenItemHandler()
        {
            if(_selectedTab?.SelectedItem != null)
            {
                await _detailService.Open(_selectedTab?.SelectedItem);
            }
        }

        public ICommand DeleteItemCommand { get; }
        private async Task DeleteItemHandler()
        {
            if(_selectedTab?.SelectedItem != null)
            {
               await  _detailService.Delete(_selectedTab?.SelectedItem);
            }

        }

        public ICommand CreateItemCommand { get; }
        private async Task CreateItemHandler(bool fromSelection)
        {

            if(fromSelection)
            {
                await _detailService.Create();
            }
            else
            {
                switch(_selectedTab)
                {
                    case PersonListingViewModel:
                        break;
                    case CarListingViewModel:
                        break;
                    case FuelCardListingViewModel:
                        break;
                    default:
                        break;
                }
            }

           
        }

    }
}
