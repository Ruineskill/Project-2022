using Xunit;
using Domain.Models;
using System;
using System.Collections.Generic;
using Domain.Models.Enums;
using Domain.Exceptions;
using System.Linq;

namespace UnitTest.Models
{
    public class FuelCardTest
    {
        static private Person _testPerson = new("test", "test", new(1962, 06, 04), "86022402508", DrivingLicenseType.B);

        [Fact]
        public void Construct_CorrectInformation_Success()
        {

            int ExceptedCardNumber = 8797687;
            DateOnly ExceptedExpirationDate = new(2030, 02, 15);
            int ExceptedPinCode = 8889;
            List<FuelType> ExceptedUsableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };



            var actual = new FuelCard(ExceptedCardNumber, ExceptedExpirationDate, ExceptedPinCode, ExceptedUsableFuelTypes);


            //Assert.Equal(actual.Id, ExceptedId);
            Assert.Equal(actual.CardNumber, ExceptedCardNumber);
            Assert.Equal(actual.ExpirationDate, ExceptedExpirationDate);
            Assert.Equal(actual.PinCode, ExceptedPinCode);
            Assert.True(actual.UsableFuelTypes.SequenceEqual(ExceptedUsableFuelTypes));
        }

        [Fact]
        public void Construct_InvalidExpirationDate_ThrowsInvalidFuelCardExpirationDateException()
        {

            // int Id = 0;
            int CardNumber = 8797687;
            DateOnly ExpirationDate = new(2000, 02, 15);
            int PinCode = 8889;
            List<FuelType> UsableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            Action actual = () => new FuelCard(CardNumber, ExpirationDate, PinCode, UsableFuelTypes);

            Assert.Throws<InvalidFuelCardExpirationDateException>(actual);
        }

        [Fact]
        public void Construct_InvalidCardNumber_ThrowsArgumentOutOfRangeException()
        {

            //int Id = 0;
            int CardNumber = 0;
            DateOnly ExpirationDate = new(2023, 02, 15);
            int PinCode = 8889;
            List<FuelType> UsableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            Action actual = () => new FuelCard(CardNumber, ExpirationDate, PinCode, UsableFuelTypes);

            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }

        [Fact]
        public void Construct_InvalidPinCode_ThrowsArgumentOutOfRangeException()
        {

            //int Id = 0;
            int CardNumber = 345345345;
            DateOnly ExpirationDate = new(2023, 02, 15);
            int PinCode = 0;
            List<FuelType> UsableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            Action actual = () => new FuelCard(CardNumber, ExpirationDate, PinCode, UsableFuelTypes);

            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }

        [Fact]
        public void Assignment_InvalidExpirationDate_ThrowsInvalidFuelCardExpirationDateException()
        {

            // int Id = 0;
            int CardNumber = 8797687;
            DateOnly ExpirationDate = new(2025, 02, 15);
            int PinCode = 8889;
            List<FuelType> UsableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            var fuelCard = new FuelCard(CardNumber, ExpirationDate, PinCode, UsableFuelTypes);

            Action actual = () => fuelCard.ExpirationDate = new(2000, 02, 15);

            Assert.Throws<InvalidFuelCardExpirationDateException>(actual);
        }

        [Fact]
        public void Assignment_InvalidCardNumber_ThrowsArgumentOutOfRangeException()
        {

            //int Id = 0;
            int CardNumber = 8797687;
            DateOnly ExpirationDate = new(2025, 02, 15);
            int PinCode = 8889;
            List<FuelType> UsableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            var fuelCard = new FuelCard(CardNumber, ExpirationDate, PinCode, UsableFuelTypes);

            Action actual = () => fuelCard.CardNumber = 0;

            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }

        [Fact]
        public void Assignment_InvalidPinCode_ThrowsArgumentOutOfRangeException()
        {

            //int Id = 0;
            int CardNumber = 8797687;
            DateOnly ExpirationDate = new(2025, 02, 15);
            int PinCode = 8889;
            List<FuelType> UsableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            var fuelCard = new FuelCard(CardNumber, ExpirationDate, PinCode, UsableFuelTypes);

            Action actual = () => fuelCard.PinCode = 0;

            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }

        [Fact]
        public void Assignment_PersonToOwnedFuelCard_ThrowsInvalidFuelCardException()
        {

            var fuelCard = new FuelCard(8797687, new(2025, 02, 15), 8889, new List<FuelType> { FuelType.Diesel, FuelType.Benzine });

            fuelCard.Person = _testPerson;

            var person = new Person("test", "test", new(1962, 06, 04), "86022402508", DrivingLicenseType.B);

            Assert.Throws<InvalidFuelCardException>(() => fuelCard.Person = person);
        }

        [Fact]
        public void Assignment_PersonToUnsupportedFuelCard_ThrowsInvalidFuelCardException()
        {

            var fuelCard = new FuelCard(8797687, new(2025, 02, 15), 8889, new List<FuelType> { FuelType.Diesel, FuelType.Benzine });

            var person = new Person("test", "test", new(1962, 06, 04), "86022402508", DrivingLicenseType.B);

            var car = new Car("Mercedes", "Class C", "5GZCZ43D13S812715", "1-ABC-235", FuelType.Hydrogen, CarType.Car);

            person.Car = car;

            Assert.Throws<InvalidFuelCardRequirementException>(() => fuelCard.Person = person);
        }


        [Theory]  // Check valid Expiration Date
        [InlineData(2030, 01, 15)]
        [InlineData(2024, 10, 09)]
        [InlineData(2022, 12, 01)]
        public void Validate_ValidExpirationDate_ReturnsTrue(int year, int month, int day)
        {
            Assert.True(FuelCard.IsValidExpirationDate(new DateOnly(year, month, day)));
        }

        [Theory]  // Check valid Expiration Date
        [InlineData(2021, 01, 15)]
        [InlineData(2022, 01, 09)]
        [InlineData(1988, 12, 01)]
        public void Validate_InvalidExpirationDate_ReturnsFalse(int year, int month, int day)
        {
            Assert.False(FuelCard.IsValidExpirationDate(new DateOnly(year, month, day)));
        }
    }
}
