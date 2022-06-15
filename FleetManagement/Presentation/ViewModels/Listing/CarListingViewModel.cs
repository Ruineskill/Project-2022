using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Presentation.DTO;
using Presentation.Exceptions;
using Presentation.Interfaces.Listing;
using Presentation.Mediators;
using Presentation.ViewModels.Bases;
using Presentation.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModels.Listing
{
    public class CarListingViewModel : TabViewModelBase
    {
        public override string Name { get; set; } = "Cars";

        private readonly CarMediator _carMediator;

        private readonly ICarListingService _carListingService;

        public ObservableCollection<ViewModelBase> Cars => _carListingService.Items;

        private ValidatedViewModelBase? _selectedItem;
        public override ValidatedViewModelBase? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public CarListingViewModel(ICarListingService carListingService, CarMediator carMediator)
        {
            _carListingService = carListingService;
            _carMediator = carMediator;

            _ = _carListingService.LoadItems();

            _carMediator.OnCreated += OnCarCreated;
            _carMediator.OnDeleted += OnCarDeleted;
            _carMediator.OnUpdated += OnCarUpdated;

        }


        private async void OnCarCreated(CarViewModel obj)
        {
            await _carListingService.Create(obj);

        }

        private async void OnCarDeleted(CarViewModel obj)
        {
            await _carListingService.Delete(obj);
        }


        private async void OnCarUpdated(CarViewModel obj)
        {
            await _carListingService.Update(obj);
        }

    }
}
