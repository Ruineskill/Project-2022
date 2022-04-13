using Xunit;
using Domain.Models;
using System;
using Domain.Models.Enums;
using Domain.Exceptions;
using Domain;

namespace UnitTest.Models
{
    public class CarTest
    {
        [Fact]
        public void Construct_CorrectInformation_Success()
        {
            // int ExceptedId = 0;
            string ExceptedChassisNumber = "1FAHP26W49G252740";
            string ExceptedLicensePlate = "1-ABC-235";
            string ExceptedBrand = "BMW";
            string ExceptedModel = "X1";
            CarType ExceptedType = CarType.Jeep;
            string ExceptedColor = "Red";
            FuelType ExceptedFuelType = FuelType.Benzine;
            int ExceptedDoorCount = 3;

            var actual = new Car(ExceptedBrand, ExceptedModel, ExceptedChassisNumber, ExceptedLicensePlate, ExceptedFuelType, ExceptedType, null, ExceptedColor, ExceptedDoorCount);


            //Assert.Equal(actual.Id, ExceptedId);
            Assert.Equal(actual.ChassisNumber, ExceptedChassisNumber);
            Assert.Equal(actual.LicensePlate, ExceptedLicensePlate);
            Assert.Equal(actual.FuelType, ExceptedFuelType);
            Assert.Equal(actual.Brand, ExceptedBrand);
            Assert.Equal(actual.Model, ExceptedModel);
            Assert.Equal(actual.Type, ExceptedType);
            Assert.Equal(actual.Color, ExceptedColor);
            Assert.Equal(actual.NumberOfDoors, ExceptedDoorCount);

        }


        [Fact]
        public void Construct_InvalidChassisNumber_ThrowsInvalidChassisNumberException()
        {

            Action actual = () => new Car("Mercedes", "Class C", "1FAHP26W4XG252740", "1-ABC-235", FuelType.Hydrogen, CarType.Van);

            Assert.Throws<InvalidChassisNumberException>(actual);

        }

        [Fact]
        public void Construct_InvalidLicencePlate_ThrowsInvalidLicensePlateException()
        {

            Action actual = () => new Car("Mercedes", "Class C", "5GZCZ43D13S812715", "A-ABC-235", FuelType.Hydrogen, CarType.Van);


            Assert.Throws<InvalidLicensePlateException>(actual);

        }

        [Fact]
        public void Construct_EmptyBrand_ThrowsArgumentNullException()
        {
            Action actual = () => new Car("", "Class C", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Van);



            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Construct_EmptyModel_ThrowsArgumentNullException()
        {

            Action actual = () => new Car("Mercedes", "", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Van);

            Assert.Throws<ArgumentNullException>(actual);

        }



        [Fact]
        public void Assignment_InvalidChassisNumber_ThrowsInvalidChassisNumberException()
        {
            var car = new Car("Mercedes", "Class C", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Van);
            Action actual = () => car.ChassisNumber = "1FAHP26W4XG252740";

            Assert.Throws<InvalidChassisNumberException>(actual);

        }

        [Fact]
        public void Assignment_InvalidLicencePlate_ThrowsInvalidLicensePlateException()
        {
            var car = new Car("Mercedes", "Class C", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Van);
            Action actual = () => car.LicensePlate = "A-ABC-235";

            Assert.Throws<InvalidLicensePlateException>(actual);

        }

        [Fact]
        public void Assignment_EmptyBrand_ThrowsArgumentNullException()
        {
            var car = new Car("Mercedes", "Class C", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Van);
            Action actual = () => car.Brand = "";

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Assignment_EmptyModel_ThrowsArgumentNullException()
        {
            var car = new Car("Mercedes", "Class C", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Van);
            Action actual = () => car.Model = "";

            Assert.Throws<ArgumentNullException>(actual);

        }




        [Theory]  // Check valid license plate
        [InlineData("1-ABC-235")]
        [InlineData("1-234-ABC")]
        [InlineData("GBA-567-3")]
        [InlineData("456-LPO-3")]
        public void Validate_ValidPlate_ReturnsTrue(string LicensePlate)
        {
            Assert.True(Car.IsValidLicensePlate(LicensePlate));
        }

        [Theory]  // Check invalid license plate
        [InlineData("1-A3C-235")]
        [InlineData("1-2B4-ABC")]
        [InlineData("gBA-567-3")]
        [InlineData("456-L6O-3")]
        public void Validate_InvalidPlate_ReturnsFalse(string LicensePlate)
        {
            Assert.False(Car.IsValidLicensePlate(LicensePlate));
        }

        [Theory]  // Check valid chassis number
        [InlineData("5GZCZ43D13S812715")]
        [InlineData("1M8GDM9AXKP042788")]
        [InlineData("1FBHP26W39G222740")]
        public void Validate_ValidChassisNumber_ReturnsTrue(string ChassisNumber)
        {
            Assert.True(Car.IsValidChassisNumber(ChassisNumber));
        }

        [Theory] // Check invalid chassis numbers
        [InlineData("1FAHP26W4XG252740")]
        [InlineData("1FAHP26349G252740")]
        [InlineData("AFAHP26349G252740")]
        public void Validate_InvalidChassisNumber_ReturnsFalse(string ChassisNumber)
        {
            Assert.False(Car.IsValidChassisNumber(ChassisNumber));
        }
    }
}
