using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private readonly Person _person;

        public string FirstName { get => _person.FirstName; set => _person.FirstName = value; }
        public string LastName { get => _person.LastName; set => _person.LastName = value; }
        public DateOnly DateOfBirth { get => _person.DateOfBirth; set => _person.DateOfBirth = value; }
        public string NationalID { get => _person.NationalRegistrationNumber; set => _person.NationalRegistrationNumber = value; }
        public DrivingLicenseType DrivingLicenseType { get => _person.DrivingLicenseType; set => _person.DrivingLicenseType = value; }
        public Address? Address { get => _person.Address; set => _person.Address = value; }
        public Car? Car { get => _person.Car; set => _person.Car = Car; }
        public FuelCard? FuelCard { get => _person.FuelCard; set => _person.FuelCard = value; }


        public PersonViewModel(Person person)
        {
            _person = person;
        }
    }
}
