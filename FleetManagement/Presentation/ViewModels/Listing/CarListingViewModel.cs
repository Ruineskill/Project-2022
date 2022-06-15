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
using System.ComponentModel;

namespace Presentation.ViewModels.Listing
{
    public class CarListingViewModel : TabViewModelBase
    {
        public override string Name { get; set; } = "Cars";

        private readonly CarMediator _carMediator;

        private readonly ICarListingService _carListingService; 

        public ICollectionView Cars { get => _carListingService.View; }
        
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

        public override void Filter(string p)
        {
            if(string.IsNullOrWhiteSpace(p))
            {
                Cars.Filter = null;
                return;
            }


            Cars.Filter = new Predicate<object>(bool (object s) =>
            {
                var car = (CarViewModel)s;
                var pre = p.ToLower();

                if(car.Brand.Contains(pre, StringComparison.CurrentCultureIgnoreCase)
                || car.Model.Contains(pre, StringComparison.CurrentCultureIgnoreCase)
                || car.ChassisNumber.Contains(pre, StringComparison.CurrentCultureIgnoreCase)) return true;
                return false;
            });
         
        }
    }
}
