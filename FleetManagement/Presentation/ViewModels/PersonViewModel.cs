#nullable disable warnings
using Domain.Models.Enums;
using Presentation.DTO;
using Presentation.ViewModels.Bases;
using System;

namespace Presentation.ViewModels
{
    public class PersonViewModel : ValidatedViewModelBase
    {
        public int Id { get; private set; }

        public string _firstName;
        public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value); }

        private string _lastName;
        public string LastName { get => _lastName; set => SetProperty(ref _lastName, value); }

        private DateOnly _dateOfBirth;
        public DateOnly DateOfBirth { get => _dateOfBirth; set => SetProperty(ref _dateOfBirth, value); }

        private string _nationalID;
        public string NationalID { get => _nationalID; set => SetProperty(ref _nationalID, value); }

        public DrivingLicenseType _drivingLicenseType;
        public DrivingLicenseType DrivingLicenseType { get => _drivingLicenseType; set => SetProperty(ref _drivingLicenseType, value); }

        private string _street;
        public string Street { get => _street; set => SetProperty(ref _street, value); }

        private int _number;
        public int Number { get => _number; set => SetProperty(ref _number, value); }

        private string _city;
        public string City { get => _city; set => SetProperty(ref _city, value); }

        private int _zipCode;
        public int ZipCode { get => _zipCode; set => SetProperty(ref _zipCode, value); }

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
                Address= new AddressDto { City = from.City, Number= from.Number, Street= from.Street, ZipCode=from.ZipCode },
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
                City = from.Address.City,
                Street = from.Address.Street,
                ZipCode = from.Address.ZipCode,
                Number=from.Address.Number,
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
