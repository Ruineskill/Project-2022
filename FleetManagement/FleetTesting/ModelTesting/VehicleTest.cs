using Xunit;
using Domain.Models;
using System;

namespace FleetTesting.ModelTesting
{
    public class VehicleTest
    {
        [Fact]
        public void DeleteVehicle()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void AddVehicle()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void ModifyVehicle()
        {
            throw new NotImplementedException();
        }



        [Theory]  // Check valid license plate
        [InlineData("1-ABC-235")]
        [InlineData("1-234-ABC")]
        [InlineData("GBA-567-3")]
        [InlineData("456-LPO-3")]
        public void LicensePlateIsValid(string LicensePlate)
        {
            Assert.True(Vehicle.IsValidLicensePlate(LicensePlate));
        }

        [Theory]  // Check invalid license plate
        [InlineData("1-A3C-235")]
        [InlineData("1-2B4-ABC")]
        [InlineData("gBA-567-3")]
        [InlineData("456-L6O-3")]
        public void LicensePlateIsNotValid(string LicensePlate)
        {
            Assert.False(Vehicle.IsValidLicensePlate(LicensePlate));
        }

        [Theory]  // Check valid chasis number
        [InlineData("1FAHP26W49G252740")]
        [InlineData("1FAHP26W49G222740")]
        [InlineData("1FBHP26W49G222740")]
        public void ChasisNumberIsValid(string ChassisNumber)
        {
            Assert.True(Vehicle.validateChassisNumber(ChassisNumber));
        }

        [Theory] // Check invalid chasis numbers
        [InlineData("1FAHP26W4XG252740")]
        [InlineData("1FAHP26349G252740")]
        [InlineData("AFAHP26349G252740")]
        public void ChasisNumberIsNotValid(string ChassisNumber)
        {
            Assert.False(Vehicle.validateChassisNumber(ChassisNumber));
        }
    }
}
