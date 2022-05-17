using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Presentation.Interfaces;
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

namespace Presentation.ViewModels
{
    public class CarListingViewModel : TabViewModelBase
    {
        public override string Name { get; set; } = "Cars";

        private readonly IHttpCarService _carService;

        private readonly CarMediator _carMediator;

        private readonly IDetailDialogService _detailDialogService;

        private ObservableCollection<CarViewModel> _cars;

        public ObservableCollection<CarViewModel> Cars { get => _cars; set => _cars = value; }

        private CarViewModel? _selectedCar;
        public CarViewModel? SelectedCar
        {
            get => _selectedCar;
            set => SetProperty(ref _selectedCar, value);
        }

        public CarListingViewModel(IHttpCarService carService, CarMediator carMediator, IDetailDialogService detailDialogService)
        {
            _cars = new();
            _carService = carService;
            _carMediator = carMediator;
            _detailDialogService = detailDialogService;

            _ = LoadCars();

            _carMediator.Created += OnCarCreated;
           
        }


        private async Task LoadCars()
        {

            await foreach(var car in _carService.GetAllStream())
            {
                _cars.Add(new CarViewModel(car));
            }
        }


        private async void OnCarCreated(Car obj)
        {
            if(await _carService.CreateAsync(obj))
            {
                _cars.Add(new CarViewModel(obj));
            }
        }


        

        public override void ReadItemHandler()
        {

            if(_selectedCar != null)
            {
                _detailDialogService.SetContent(_selectedCar);
                _detailDialogService.Show();
            }

          
        }

        public override void EditItemHandler()
        {
            throw new NotImplementedException();
        }

        public override void DeleteItemHandler()
        {
            throw new NotImplementedException();
        }
    }
}
