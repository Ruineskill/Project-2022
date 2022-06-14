using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Presentation.DTO;
using Presentation.Exceptions;
using Presentation.Interfaces.Listing;
using Presentation.Mediators;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation.ViewModels.Listing
{
    public class FuelCardListingViewModel : TabViewModelBase
    {
        public override string Name { get; set; } = "Fuel Cards";

        private readonly IFuelCardListingService _fuelCardListingService;

        private readonly FuelCardMediator _fuelCardMediator;

        public ObservableCollection<ViewModelBase> FuelCards => _fuelCardListingService.Items;

        private ViewModelBase? _selectedItem;
        public override ViewModelBase? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public FuelCardListingViewModel(IFuelCardListingService fuelCardListingService, FuelCardMediator fuelCardMediator)
        {
            _fuelCardListingService = fuelCardListingService;
            _fuelCardMediator = fuelCardMediator;

            _ = _fuelCardListingService.LoadItems();

            _fuelCardMediator.OnCreated += OnFuelCardCreated;
            _fuelCardMediator.OnDeleted += OnFuelCardDeleted;
            _fuelCardMediator.OnUpdated += OnFuelCardUpdated;
        }

        private async void OnFuelCardCreated(FuelCardViewModel obj)
        {
            await _fuelCardListingService.Create(obj);
        }

        private async void OnFuelCardDeleted(FuelCardViewModel obj)
        {
            await _fuelCardListingService.Delete(obj);
        }

        private async void OnFuelCardUpdated(FuelCardViewModel obj)
        {
            await _fuelCardListingService.Update(obj);
        }
    }
}
