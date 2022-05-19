using Domain.Models;
using Domain.Models.Enums;
using Presentation.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class PersonViewModel : DetailViewModelBase
    {
        public readonly Person Person;

        public string FirstName { get => Person.FirstName; set => Person.FirstName = value; }
        public string LastName { get => Person.LastName; set => Person.LastName = value; }
        public DateOnly DateOfBirth { get => Person.DateOfBirth; set => Person.DateOfBirth = value; }
        public string NationalID { get => Person.NationalRegistrationNumber; set => Person.NationalRegistrationNumber = value; }
        public DrivingLicenseType DrivingLicenseType { get => Person.DrivingLicenseType; set => Person.DrivingLicenseType = value; }
        public Address? Address { get => Person.Address; set => Person.Address = value; }
        public Car? Car { get => Person.Car; set => Person.Car = Car; }
        public FuelCard? FuelCard { get => Person.FuelCard; set => Person.FuelCard = value; }


        public PersonViewModel(Person person)
        {
            Person = person;
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
