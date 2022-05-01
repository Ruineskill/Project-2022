using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentation.ViewModels
{
    public class CarListingViewModel : TabViewModelBase
    {
        public override string Name { get; set; } = "Cars";

        private readonly IHttpCarService _carService;

        private ObservableCollection<CarViewModel> _cars;

        public ObservableCollection<CarViewModel> Cars { get => _cars; set => _cars = value; }

        private CarViewModel? _selectedCar;
        public CarViewModel? SelectedCar
        {
            get => _selectedCar;
            set => SetProperty(ref _selectedCar, value);
        }

        public CarListingViewModel(IHttpCarService carService)
        {
            _carService = carService;
            _cars = new();
            LoadCars();
        }

        private async void LoadCars()
        {
            var cars = await _carService.GetAllAsync();
            foreach(var c in cars) _cars.Add(new CarViewModel(c));

        }
    }
}
