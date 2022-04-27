using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Enums;

namespace Presentation.ViewModels
{
    public class CarViewModel : ViewModelBase
    {
        private readonly Car _car;

        public int Id => _car.Id;
        public string Brand =>_car.Brand;
        public string Model =>_car.Model;
        public string ChassisNumber =>_car.ChassisNumber;
        public string LicensePlate=>_car.LicensePlate;
        public FuelType FuelType => _car.FuelType;
        public CarType Type =>_car.Type;
        public Person? Person =>_car.Person;
        public string? Color =>_car.Color;
        public int NumberOfDoors => _car.NumberOfDoors;
        public bool Delete => _car.Delete;
        public DrivingLicenseType RequiredLicence => _car.RequiredLicence;



        public CarViewModel(Car car)
        {
            _car = car;
        }
    }
}
