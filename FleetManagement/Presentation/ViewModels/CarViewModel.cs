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
    public class CarViewModel : ViewModelBase
    {

    

        public int Id { get; private set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ChassisNumber { get; set; }
        public string LicensePlate { get; set; }
        public FuelType FuelType { get; set; }
        public CarType Type { get; set; }
        public string Color { get; set; }
        public int NumberOfDoors { get; set; }
        public DrivingLicenseType RequiredLicence { get; private set; }

        private PersonViewModel? _person;
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

       
    }
}
