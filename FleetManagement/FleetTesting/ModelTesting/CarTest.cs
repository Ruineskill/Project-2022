using Xunit;
using Domain.Models;
using System;
using Domain.Models.Enums;
using Domain.Exceptions;

namespace FleetTesting.ModelTesting
{
    public class CarTest
    {
        [Fact]
        public void Construct_WithCorrectInformation_ShouldConstruct()
        {

            
            throw new NotImplementedException();
        }


        [Fact]
        public void Construct_WithInvalidChassisNumber_ThrowsInvalidChassisNumberException()
        {
            Fuel carFuel = new(0, "Benzine");

            Action actual = () => new Car(0, "1FAHP26W4XG252740", "1-ABC-235", "Mercedes", "Class C", carFuel, CarType.Car);

            Assert.Throws<InvalidChassisNumberException>(actual);
           
        }


        [Theory]  // Check valid license plate
        [InlineData("1-ABC-235")]
        [InlineData("1-234-ABC")]
        [InlineData("GBA-567-3")]
        [InlineData("456-LPO-3")]
        public void Validate_PassedValidPlate_ReturndTrue(string LicensePlate)
        {
            Assert.True(Car.IsValidLicensePlate(LicensePlate));
        }

        [Theory]  // Check invalid license plate
        [InlineData("1-A3C-235")]
        [InlineData("1-2B4-ABC")]
        [InlineData("gBA-567-3")]
        [InlineData("456-L6O-3")]
        public void Validate_PassedInvalidPlate_ReturndFalse(string LicensePlate)
        {
            Assert.False(Car.IsValidLicensePlate(LicensePlate));
        }

        [Theory]  // Check valid chasis number
        [InlineData("1FAHP26W49G252740")]
        [InlineData("1FAHP26W49G222740")]
        [InlineData("1FBHP26W49G222740")]
        public void Validate_PassedValidChassisNumber_ReturndTrue(string ChassisNumber)
        {
            Assert.True(Car.IsValidChassisNumber(ChassisNumber));
        }

        [Theory] // Check invalid chasis numbers
        [InlineData("1FAHP26W4XG252740")]
        [InlineData("1FAHP26349G252740")]
        [InlineData("AFAHP26349G252740")]
        public void Validate_PassedInvalidChassisNumber_ReturndFalse(string ChassisNumber)
        {
            Assert.False(Car.IsValidChassisNumber(ChassisNumber));
        }
    }
}
