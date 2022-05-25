using Domain.Models;
using Domain.Models.Enums;
using Presentation.Interfaces;
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

        public readonly Car Car;

        IHttpCarService _httpCarService;
        public string Brand { get => Car.Brand; set => Car.Brand = value; }
        public string Model { get => Car.Model; set => Car.Model = value; }
        public string ChassisNumber { get => Car.ChassisNumber; set => Car.ChassisNumber = value; }
        public string LicensePlate { get => Car.LicensePlate; set => Car.LicensePlate = value; }
        public FuelType FuelType { get => Car.FuelType; set => Car.FuelType = value; }
        public ICollection<FuelType> FuelTypes { get; set; } = new List<FuelType>();
        public CarType Type { get => Car.Type; set => Car.Type = value; }
        public Person? Person { get => Car.Person; set => Car.Person = value; }
        public string? Color { get => Car.Color; set => Car.Color = value; }
        public int NumberOfDoors { get => Car.NumberOfDoors; set => Car.NumberOfDoors = value; }
        public DrivingLicenseType RequiredLicence { get => Car.RequiredLicence; }


        public CarViewModel(Car car, IHttpCarService httpCarService)
        {
            Car = car;
            _httpCarService = httpCarService;

            foreach (var fuelType in Enum.GetValues<FuelType>())
            {
                FuelTypes.Add(fuelType);
            }
        }

        public override void Save()
        {
            return;
        }
    }
}
