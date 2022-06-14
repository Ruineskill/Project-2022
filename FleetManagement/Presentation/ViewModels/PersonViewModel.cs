#nullable disable warnings
using Domain.Models.Enums;
using Presentation.DTO;
using Presentation.ViewModels.Bases;
using System;

namespace Presentation.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string NationalID { get; set; }


        public DrivingLicenseType _drivingLicenseType;
        public DrivingLicenseType DrivingLicenseType { get => _drivingLicenseType; set => SetProperty(ref _drivingLicenseType, value); }
        public AddressViewModel Address { get; set; } = new AddressViewModel();

        private CarViewModel? _car;
        public CarViewModel? Car { get => _car; set => SetProperty(ref _car, value); }

        private FuelCardViewModel? _fuelCard;
        public FuelCardViewModel? FuelCard { get => _fuelCard; set => SetProperty(ref _fuelCard, value); }



        public static implicit operator PersonDto(PersonViewModel from)
        {
            if(from == null) return null;
            return new PersonDto
            {
                Id = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                DateOfBirth = from.DateOfBirth,
                NationalRegistrationNumber = from.NationalID,
                DrivingLicenseType = from.DrivingLicenseType,
                Address = from.Address,
                Car = from.Car,
                FuelCard = from.FuelCard,
            };
        }
        public static implicit operator PersonViewModel(PersonDto from)
        {
            if(from == null) return null;
            return new PersonViewModel
            {
                Id = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                DateOfBirth = from.DateOfBirth,
                NationalID = from.NationalRegistrationNumber,
                DrivingLicenseType = from.DrivingLicenseType,
                Address = from.Address,
                Car = from.Car,
                FuelCard = from.FuelCard,
            };
        }


        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public PersonViewModel ShallowCopy()
        {
            return (PersonViewModel)this.MemberwiseClone();
        }


    }
}
