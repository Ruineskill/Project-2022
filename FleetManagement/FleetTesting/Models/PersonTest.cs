using Xunit;
using Domain.Models;
using System;
using System.Collections.Generic;
using Domain.Models.Enums;
using Domain.Exceptions;

namespace FleetTesting.ModelTesting
{
    public class PersonTest
    {
        [Fact]
        public void Construct_CorrectInformation_ShouldConstruct()
        {
            int ExceptedId = 0;
            const string ExceptedFirstName = "Luc";
            const string ExceptedLastName = "skywalker";
            DateOnly ExceptedDateOfBirth = new DateOnly(2000, 09, 01);
            const string ExceptedNationalRegistrationNumber = "86022402508";
            DrivingLicenseType ExceptedDrivingLicenseTypes = DrivingLicenseType.B;


            var actual = new Person(ExceptedId, ExceptedFirstName, ExceptedLastName,
                ExceptedDateOfBirth, ExceptedNationalRegistrationNumber, ExceptedDrivingLicenseTypes);


            Assert.Equal(actual.Id, ExceptedId);
            Assert.Equal(actual.FirstName, ExceptedFirstName);
            Assert.Equal(actual.LastName, ExceptedLastName);
            Assert.Equal(actual.DateOfBirth, ExceptedDateOfBirth);
            Assert.Equal(actual.NationalRegistrationNumber, ExceptedNationalRegistrationNumber);
            Assert.Equal(actual.DrivingLicenseType, ExceptedDrivingLicenseTypes);


        }


        [Fact]
        public void Construct_EmptyFirstName_ThrowsArgumentNullException()
        {
            int Id = 0;
            const string FirstName = "";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;


            var actual = () => new Person(Id, FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Construct_EmptyLastName_ThrowsArgumentNullException()
        {
            int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;


            Action actual = () => new Person(Id, FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Assert.Throws<ArgumentNullException>(actual);

        }


        [Fact]
        public void Construct_InvalidDateOfBirth_ThrowsInvalidDateOfBirthException()
        {
            int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2023, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;


            Action actual = () => new Person(Id, FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Assert.Throws<InvalidDateOfBirthException>(actual);

        }

        [Fact]
        public void Construct_InvalidNationalRegistrationNumber_ThrowsInvalidDateOfBirthException()
        {
            int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "60061812451";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;

            Action actual = () => new Person(Id, FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Assert.Throws<InvalidNationRegistrationNumberException>(actual);

        }

        [Fact]
        public void Assignment_EmptyFirstName_ThrowsArgumentNullException()
        {
            int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;

            var persion = new Person(Id, FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Action actual = () => persion.FirstName = "";

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Assignment_EmptyLastName_ThrowsArgumentNullException()
        {
            int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;

            var persion = new Person(Id, FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Action actual = () => persion.LastName = "";

            Assert.Throws<ArgumentNullException>(actual);

        }

        [Fact]
        public void Assignment_InvalidDateOfBirt_ThrowsInvalidDateOfBirthException()
        {
            int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;

            var persion = new Person(Id, FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Action actual = () => persion.DateOfBirth = new DateOnly(2023, 09, 01);

            Assert.Throws<InvalidDateOfBirthException>(actual);

        }

        [Fact]
        public void Assignment_InvalidNationalRegistrationNumber_ThrowsInvalidNationRegistrationNumberException()
        {
            int Id = 0;
            const string FirstName = "Luc";
            const string LastName = "skywalker";
            DateOnly DateOfBirth = new DateOnly(2000, 09, 01);
            const string NationalRegistrationNumber = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;

            var persion = new Person(Id, FirstName, LastName, DateOfBirth, NationalRegistrationNumber, DrivingLicenseTypes);

            Action actual = () => persion.NationalRegistrationNumber = "86022402502";

            Assert.Throws<InvalidNationRegistrationNumberException>(actual);

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