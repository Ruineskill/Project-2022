using Xunit;
using Domain.Models;
using System;
using Domain.Models.Enums;
using Domain.Exceptions;

namespace UnitTest.Models
{
    public class AdressTest
    {
        [Fact]
        public void Construct_CorrectInformation_Success()
        {

            const string ExceptedStreet = "Somestraat";
            const int ExceptedStreetNumber = 2;
            const string ExceptedCity = "Brussel";
            const int ExceptedZipCode = 9000;


            var actual = new Address(ExceptedStreet, ExceptedStreetNumber, ExceptedCity, ExceptedZipCode);


            Assert.Equal(actual.Street, ExceptedStreet);
            Assert.Equal(actual.Number, ExceptedStreetNumber);
            Assert.Equal(actual.City, ExceptedCity);
            Assert.Equal(actual.ZipCode, ExceptedZipCode);
        }

        [Fact]
        public void Construct_EmptyStreet_ThrowsArgumentNullException()
        {
            const string ExceptedStreet = "";
            const int ExceptedStreetNumber = 2;
            const string ExceptedCity = "Brussel";
            const int ExceptedZipCode = 9000;
            Action actual = () => new Address(ExceptedStreet, ExceptedStreetNumber, ExceptedCity, ExceptedZipCode);



            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Construct_EmptyCity_ThrowsArgumentNullException()
        {
            const string ExceptedStreet = "Somestraat";
            const int ExceptedStreetNumber = 2;
            const string ExceptedCity = "";
            const int ExceptedZipCode = 9000;

            Action actual = () => new Address(ExceptedStreet, ExceptedStreetNumber, ExceptedCity, ExceptedZipCode);

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Construct_InvalidPostalCode_ThrowsInvalidPostalCodeException()
        {
            const string ExceptedStreet = "Somestraat";
            const int ExceptedStreetNumber = 2;
            const string ExceptedCity = "Brussel";
            const int ExceptedZipCode = 90000;

            Action actual = () => new Address(ExceptedStreet, ExceptedStreetNumber, ExceptedCity, ExceptedZipCode);

            Assert.Throws<InvalidPostalCodeException>(actual);

        }

        [Fact]
        public void Assignment_EmptyStreet_ThrowsArgumentNullException()
        {
            const string ExceptedStreet = "Somestraat";
            const int ExceptedStreetNumber = 2;
            const string ExceptedCity = "Brussel";
            const int ExceptedZipCode = 9000;
            var address = new Address(ExceptedStreet, ExceptedStreetNumber, ExceptedCity, ExceptedZipCode);

            Action actual = () => address.Street = "";

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Assignment_EmptyCity_ThrowsArgumentNullException()
        {
            const string ExceptedStreet = "Somestraat";
            const int ExceptedStreetNumber = 2;
            const string ExceptedCity = "Brussel";
            const int ExceptedZipCode = 9000;
            var address = new Address(ExceptedStreet, ExceptedStreetNumber, ExceptedCity, ExceptedZipCode);

            Action actual = () => address.City = "";

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Assignment_InvalidPostalCode_ThrowsInvalidPostalCodeException()
        {
            const string ExceptedStreet = "Somestraat";
            const int ExceptedStreetNumber = 2;
            const string ExceptedCity = "Brussel";
            const int ExceptedZipCode = 9000;
            var address = new Address(ExceptedStreet, ExceptedStreetNumber, ExceptedCity, ExceptedZipCode);

            Action actual = () => address.ZipCode = 1;

            Assert.Throws<InvalidPostalCodeException>(actual);

        }



        [Theory]  // Check valid postal code
        [InlineData(1000)]
        [InlineData(8000)]
        [InlineData(6000)]
        [InlineData(9000)]
        public void Validate_ValidPostalCode_ReturnsTrue(int code)
        {
            Assert.True(Address.IsValidPostalCode(code));
        }

        [Theory]  // Check valid postal code
        [InlineData(1)]
        [InlineData(8)]
        [InlineData(60000)]
        [InlineData(9999)]
        public void Validate_InvalidPostalCode_ReturnsFalse(int code)
        {
            Assert.False(Address.IsValidPostalCode(code));
        }
    }
}
