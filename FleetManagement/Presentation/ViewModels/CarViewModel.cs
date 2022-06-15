#nullable disable warnings
using Domain.Models.Enums;
using Presentation.DTO;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class CarViewModel : ValidatedViewModelBase
    {
        private PersonViewModel? _person;
        private CarType _type;
        private DrivingLicenseType _requiredLicence;
        private FuelType _fuelType;
        private string _licensePlate;
        private string _chassisNumber;
        private string _model;
        private string _brand;


        public int Id { get; private set; }

        public string Brand { get => _brand; set => SetProperty(ref _brand,value); }

        public string Model { get => _model; set => SetProperty(ref _model, value); }

        public string ChassisNumber { get => _chassisNumber; set => SetProperty(ref _chassisNumber, value); }

        public string LicensePlate { get => _licensePlate; set => SetProperty(ref _licensePlate, value); }

        public FuelType FuelType { get => _fuelType; set => SetProperty(ref _fuelType, value); }

        public CarType Type
        {
            get => _type;
            set
            {
                _requiredLicence = GetLicenceForCarType(value);
                SetProperty(ref _type, value);              
            }
        }

        public string Color { get; set; }

        public int NumberOfDoors { get; set; }

        public DrivingLicenseType RequiredLicence { get => _requiredLicence; private set => _requiredLicence = value; }




        public PersonViewModel? Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }




        public static implicit operator CarDto(CarViewModel from)
        {
            if(from == null) return null;
            return new CarDto
            {
                Id = from.Id,
                Brand = from.Brand,
                Model = from.Model,
                ChassisNumber = from.ChassisNumber,
                LicensePlate = from.LicensePlate,
                FuelType = from.FuelType,
                Type = from.Type,
                Person = from.Person,
                Color = from.Color,
                NumberOfDoors = from.NumberOfDoors,
                RequiredLicence = from.RequiredLicence,
            };
        }

        public static implicit operator CarViewModel(CarDto from)
        {
            if(from == null) return null;
            return new CarViewModel
            {
                Id = from.Id,
                Brand = from.Brand,
                Model = from.Model,
                ChassisNumber = from.ChassisNumber,
                LicensePlate = from.LicensePlate,
                FuelType = from.FuelType,
                Type = from.Type,
                Person = from.Person,
                Color = from.Color,
                NumberOfDoors = from.NumberOfDoors,
                RequiredLicence = from.RequiredLicence,
            };
        }

        public override string ToString()
        {
            return $"Brand: {Brand} Model: {Model}";
        }

        public CarViewModel ShallowCopy()
        {
            return (CarViewModel)this.MemberwiseClone();
        }

        public static DrivingLicenseType GetLicenceForCarType(CarType type)
        {
            if(type == CarType.Truck)
            {
                return DrivingLicenseType.C;
            }
            else if(type == CarType.Bus)
            {
                return DrivingLicenseType.D;
            }

            return DrivingLicenseType.B;
        }
    }
}
