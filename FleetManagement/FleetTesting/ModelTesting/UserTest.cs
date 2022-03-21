using Xunit;
using Domain.Models;
using System;
namespace FleetTesting.ModelTesting
{
    public class UserTest
    {


        [Theory]  // Check valid National Number
        [InlineData("86022402508")]
        [InlineData("60061812456")]
        [InlineData("44121181161")]
        public void Validate_ValidNationalNumber_ReturndTrue(string RegistrationNumber)
        {
            Assert.True(User.IsValidNationalRegistrationNumber(RegistrationNumber));
        }

        [Theory] // Check invalid National Number
        [InlineData("86022402502")]
        [InlineData("60061812451")]
        [InlineData("44121181160")]
        public void Validate_InvalidNationNumber_ReturndFalse(string RegistrationNumber)
        {
            Assert.False(User.IsValidNationalRegistrationNumber(RegistrationNumber));
        }

    }
}