using Xunit;
using Domain.Models;
using System;
using System.Collections.Generic;
using Domain.Models.Enums;
using Domain.Exceptions;

namespace UnitTest.Models
{
    public class PersonTest
    {

        [Fact]
        public void Construct_CorrectInformation_Success()
        {
            // int ExceptedId = 0;
            const string ExceptedFirstName = "Luc";
            const string ExceptedLastName = "skywalker";
            DateOnly ExceptedDateOfBirth = new DateOnly(2000, 09, 01);
            const string ExceptedNationalRegistrationNumber = "86022402508";
            DrivingLicenseType ExceptedDrivingLicenseTypes = DrivingLicenseType.B;


            var actual = new Person(ExceptedFirstName, ExceptedLastName,
                ExceptedDateOfBirth, ExceptedNationalRegistrationNumber, ExceptedDrivingLicenseTypes);


            //Assert.Equal(actual.Id, ExceptedId);
            Assert.Equal(actual.FirstName, ExceptedFirstName);
            Assert.Equal(actual.LastName, ExceptedLastName);
            Assert.Equal(actual.DateOfBirth, ExceptedDateOfBirth);
            Assert.Equal(actual.NationalRegistrationNumber, ExceptedNationalRegistrationNumber);
            Assert.Equal(actual.DrivingLicenseType, ExceptedDrivingLicenseTypes);


        }

        [Fact]
        public void Construct_EmptyFirstName_ThrowsArgumentNullException()
        {
            //int Id = 0;
            const string FirstName = "";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;


            var actual = () => new Person(FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Construct_EmptyLastName_ThrowsArgumentNullException()
        {
            // int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;


            Action actual = () => new Person(FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Construct_InvalidDateOfBirth_ThrowsInvalidDateOfBirthException()
        {
            //int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2023, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;


            Action actual = () => new Person(FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Assert.Throws<InvalidDateOfBirthException>(actual);

        }

        [Fact]
        public void Construct_InvalidNationalRegistrationNumber_ThrowsInvalidDateOfBirthException()
        {
            // int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "60061812451";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;

            Action actual = () => new Person(FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Assert.Throws<InvalidNationRegistrationNumberException>(actual);

        }

        [Fact]
        public void Assignment_EmptyFirstName_ThrowsArgumentNullException()
        {
            //int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;

            var persion = new Person(FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Action actual = () => persion.FirstName = "";

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Assignment_EmptyLastName_ThrowsArgumentNullException()
        {
            // int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;

            var persion = new Person(FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Action actual = () => persion.LastName = "";

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Assignment_InvalidDateOfBirt_ThrowsInvalidDateOfBirthException()
        {
            //int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;

            var persion = new Person(FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Action actual = () => persion.DateOfBirth = new DateOnly(2023, 09, 01);

            Assert.Throws<InvalidDateOfBirthException>(actual);

        }

        [Fact]
        public void Assignment_InvalidNationalRegistrationNumber_ThrowsInvalidNationRegistrationNumberException()
        {
            //int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;

            var persion = new Person(FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Action actual = () => persion.NationalRegistrationNumber = "86022402502";

            Assert.Throws<InvalidNationRegistrationNumberException>(actual);

        }

        [Fact]
        public void Assignment_OwnedCar_ThrowsInvaliCarException()
        {

            var person = new Person("test", "test", new(1962, 06, 04), "86022402508", DrivingLicenseType.B);

            var car = new Car("Mercedes", "Class C", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Car);
            car.Person = new Person("test2", "test2", new(1962, 06, 04), "86022402508", DrivingLicenseType.B);


            Assert.Throws<InvalidCarException>(() => person.Car = car);

        }

        [Fact]
        public void Assignment_OwnedFuelCard_ThrowsInvaliFuelCardException()
        {

            var person = new Person("test", "test", new(1962, 06, 04), "86022402508", DrivingLicenseType.B);

            var fuelCard = new FuelCard(8797687, new(2025, 02, 15), 8889, new List<FuelType> { FuelType.Diesel, FuelType.Benzine });
            fuelCard.Person = new Person("test2", "test2", new(1962, 06, 04), "86022402508", DrivingLicenseType.B);


            Assert.Throws<InvalidFuelCardException>(() => person.FuelCard = fuelCard);

        }

        [Fact]
        public void Assignment_CarWithUnsupportedLicence_ThrowsInvalidLicenceTypeRequirementException()
        {

            var person = new Person("test", "test", new(1962, 06, 04), "86022402508", DrivingLicenseType.B);
            var car = new Car("Mercedes", "Class C", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Bus);



            Assert.Throws<InvalidLicenceTypeRequirementException>(() => person.Car = car);

        }


        [Fact]
        public void Assignment_CarWithUnsupportedFuelCard_ThrowsInvalidFuelCardRequirementException()
        {

            var person = new Person("test", "test", new(1962, 06, 04), "86022402508", DrivingLicenseType.B);
            person.FuelCard = new FuelCard(8797687, new(2025, 02, 15), 8889, new List<FuelType> { FuelType.Diesel, FuelType.Benzine });

            var car = new Car("Mercedes", "Class C", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Car);



            Assert.Throws<InvalidFuelCardRequirementException>(() => person.Car = car);

        }

        [Fact]
        public void Assignment_FuelCardWithUnsupportedCar_ThrowsInvalidFuelCardRequirementException()
        {

            var person = new Person("test", "test", new(1962, 06, 04), "86022402508", DrivingLicenseType.B);
            person.Car = new Car("Mercedes", "Class C", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Car);

            var fuelCard = new FuelCard(8797687, new(2025, 02, 15), 8889, new List<FuelType> { FuelType.Diesel, FuelType.Benzine });


            Assert.Throws<InvalidFuelCardRequirementException>(() => person.FuelCard = fuelCard);

        }


        [Theory]  // Check valid National Number
        [InlineData("86022402508")]
        [InlineData("60061812456")]
        [InlineData("44121181161")]
        public void Validate_ValidNationalNumber_ReturndTrue(string RegistrationNumber)
        {
            Assert.True(Person.IsValidNationalRegistrationNumber(RegistrationNumber));
        }

        [Theory] // Check invalid National Number
        [InlineData("86022402502")]
        [InlineData("60061812451")]
        [InlineData("44121181160")]
        public void Validate_InvalidNationNumber_ReturndFalse(string RegistrationNumber)
        {
            Assert.False(Person.IsValidNationalRegistrationNumber(RegistrationNumber));
        }

    }
}