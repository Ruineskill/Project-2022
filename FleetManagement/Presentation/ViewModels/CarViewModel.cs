using Domain.Models;
using Domain.Models.Enums;
using Presentation.Mediators;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class CarViewModel : DetailViewModelBase
    {

        private readonly Car _car;

        public string Brand { get => _car.Brand; set => _car.Brand = value; }
        public string Model { get => _car.Model; set => _car.Model = value; }
        public string ChassisNumber { get => _car.ChassisNumber; set => _car.ChassisNumber = value; }
        public string LicensePlate { get => _car.LicensePlate; set => _car.LicensePlate = value; }
        public FuelType FuelType { get => _car.FuelType; set => _car.FuelType = value; }
        public CarType Type { get => _car.Type; set => _car.Type = value; }
        public Person? Person { get => _car.Person; set => _car.Person = value; }
        public string? Color { get => _car.Color; set => _car.Color = value; }
        public int NumberOfDoors { get => _car.NumberOfDoors; set => _car.NumberOfDoors = value; }
        public DrivingLicenseType RequiredLicence { get => _car.RequiredLicence; }


        public CarViewModel(Car car)
        {
            _car = car;
          
        }

        public override void Save()
        {
            return;
        }
    }
}
