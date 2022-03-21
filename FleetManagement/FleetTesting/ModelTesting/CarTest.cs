using Xunit;
using Domain.Models;
using System;
using Domain.Models.Enums;
using Domain.Exceptions;
using Moq;

namespace FleetTesting.ModelTesting
{
    public class CarTest
    {
        [Fact]
        public void Construct_CorrectInformation_ShouldConstruct()
        {
            int ExceptedId = 0;
            string ExceptedChassisNumber = "1FAHP26W49G252740";
            string ExceptedLicensePlate = "1-ABC-235";
            string ExceptedBrand = "BMW";
            string ExceptedModel = "X1";
            CarType ExceptedType = CarType.Jeep;
            Fuel ExceptedFuel = new(0, "Benzine");
            string ExceptedColor = "Red";
            int ExceptedDoorCount = 3;
            User ExceptedUser = new(0, "Luc", "SkyWalker", "nabustreet", "3",
                "Polis Massa", 9000, new DateOnly(1000, 02, 01), "86022402508", "B");

            var actual = new Car(ExceptedId, ExceptedChassisNumber, ExceptedLicensePlate, ExceptedBrand, ExceptedModel,
                                 ExceptedFuel, ExceptedType, ExceptedColor, ExceptedDoorCount, ExceptedUser);


            Assert.Equal(actual.Id, ExceptedId);
            Assert.Equal(actual.ChassisNumber, ExceptedChassisNumber);
            Assert.Equal(actual.LicensePlate, ExceptedLicensePlate);
            Assert.Equal(actual.Brand, ExceptedBrand);
            Assert.Equal(actual.Model, ExceptedModel);
            Assert.Equal(actual.Type, ExceptedType);
            Assert.Equal(actual.Fuel.Id, ExceptedFuel.Id);
            Assert.Equal(actual.Fuel.Type, ExceptedFuel.Type);
            Assert.Equal(actual.Color, ExceptedColor);
            Assert.Equal(actual.DoorCount, ExceptedDoorCount);

            Assert.Equal(actual.User.Id, ExceptedUser.Id);
            Assert.Equal(actual.User.FirstName, ExceptedUser.FirstName);
            Assert.Equal(actual.User.Name, ExceptedUser.Name);
            Assert.Equal(actual.User.Street, ExceptedUser.Street);
            Assert.Equal(actual.User.HouseNumber, ExceptedUser.HouseNumber);
            Assert.Equal(actual.User.City, ExceptedUser.City);
            Assert.Equal(actual.User.PostalCode, ExceptedUser.PostalCode);
            Assert.Equal(actual.User.DayOfBirth, ExceptedUser.DayOfBirth);
            Assert.Equal(actual.User.NationRegistrationNumber, ExceptedUser.NationRegistrationNumber); ;
            Assert.Equal(actual.User.DriversLicenseType, ExceptedUser.DriversLicenseType); ;


        }


        [Fact]
        public void Construct_InvalidChassisNumber_ThrowsInvalidChassisNumberException()
        {

            Fuel carFuel = new(0, "Benzine");
            Action actual = () => new Car(0, "1FAHP26W4XG252740", "1-ABC-235", "Mercedes", "Class C", carFuel, CarType.Car);

            Assert.Throws<InvalidChassisNumberException>(actual);

        }

        [Fact]
        public void Construct_InvalidLicencePlate_ThrowsInvalidLicensePlateException()
        {

            Fuel carFuel = new(0, "Benzine");
            Action actual = () => new Car(0, "1M8GDM9AXKP042788", "A-ABC-235", "Mercedes", "Class C", carFuel, CarType.Car);

            Assert.Throws<InvalidLicensePlateException>(actual);

        }

        [Fact]
        public void Construct_EmptyBrand_ThrowsArgumentNullException()
        {

            Fuel carFuel = new(0, "Benzine");
            Action actual = () => new Car(0, "1M8GDM9AXKP042788", "1-ABC-235", "", "Class C", carFuel, CarType.Car);

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Construct_EmptyModel_ThrowsArgumentNullException()
        {

            Fuel carFuel = new(0, "Benzine");
            Action actual = () => new Car(0, "1M8GDM9AXKP042788", "1-ABC-235", "Mercedes", "", carFuel, CarType.Car);

            Assert.Throws<ArgumentNullException>(actual);

        }


        [Theory]  // Check valid license plate
        [InlineData("1-ABC-235")]
        [InlineData("1-234-ABC")]
        [InlineData("GBA-567-3")]
        [InlineData("456-LPO-3")]
        public void Validate_ValidPlate_ReturndTrue(string LicensePlate)
        {
            Assert.True(Car.IsValidLicensePlate(LicensePlate));
        }

        [Theory]  // Check invalid license plate
        [InlineData("1-A3C-235")]
        [InlineData("1-2B4-ABC")]
        [InlineData("gBA-567-3")]
        [InlineData("456-L6O-3")]
        public void Validate_InvalidPlate_ReturndFalse(string LicensePlate)
        {
            Assert.False(Car.IsValidLicensePlate(LicensePlate));
        }

        [Theory]  // Check valid chassis number
        [InlineData("5GZCZ43D13S812715")]
        [InlineData("1M8GDM9AXKP042788")]
        [InlineData("1FBHP26W39G222740")]
        public void Validate_ValidChassisNumber_ReturndTrue(string ChassisNumber)
        {
            Assert.True(Car.IsValidChassisNumber(ChassisNumber));
        }

        [Theory] // Check invalid chassis numbers
        [InlineData("1FAHP26W4XG252740")]
        [InlineData("1FAHP26349G252740")]
        [InlineData("AFAHP26349G252740")]
        public void Validate_InvalidChassisNumber_ReturndFalse(string ChassisNumber)
        {
            Assert.False(Car.IsValidChassisNumber(ChassisNumber));
        }
    }
}
