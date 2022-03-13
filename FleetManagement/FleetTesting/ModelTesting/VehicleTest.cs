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

       

        [Fact]  // check if duplication of license plate is disallowed
        public void LicensePlateCheck()
        {
            throw new NotImplementedException();
        }

        

        [Fact]  // Check if chasis number is valid
        public void IsValidChasisNumber()
        {
            //arrange
            Vehicle vehicle = new Vehicle(
                                1,
                                "1FAHP26W49G252740",
                                "test",
                                "test",
                                "test",
                                Domain.Models.Enums.VehicleType.Car,
                                "red",
                                5
                              );
            //act
            bool isValid = Vehicle.validateChassisNumber(vehicle.ChassisNumber);

            //assert
            Assert.True(isValid, $"The VNI number: ${vehicle.ChassisNumber} is not valid");

        }
    }
}
