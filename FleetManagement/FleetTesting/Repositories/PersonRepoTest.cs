using Domain.Models;
using Domain.Models.Enums;
using Repository.Exceptions;
using Repository.Repositories;
using System;
using System.Linq;
using UnitTest.Repositories.Fixtures;
using Xunit;
namespace UnitTest.Repositories
{
    [Collection("RepoCollection")]
    public class PersonRepoTest : IClassFixture<PersonFixture>
    {
        private readonly PersonRepository _repo;
        private readonly PersonFixture _fixture;


        public PersonRepoTest(PersonFixture fixture)
        {
            _fixture = fixture;
            _repo = new PersonRepository(_fixture.CreateContext());
        }

        [Fact]
        public async void AddPerson_ValidPerson_Success()
        {

            const string exceptedFirstName = "Qui-Gon";
            const string exceptedLastName = "Jinn";
            DateOnly exceptedDateOfBirth = new(1957, 07, 09);
            const string exceptedNationalId = "57070991264";
            DrivingLicenseType exceptedDrivingLicenseType = DrivingLicenseType.B;
            Address exceptedAdress = new("jinnstreet", 840, "Brussel", 1000);

            var person = new Person(exceptedFirstName, exceptedLastName, exceptedDateOfBirth, exceptedNationalId, exceptedDrivingLicenseType)
            {
                Address = exceptedAdress
            };


            await _repo.AddAsync(person);
            var savedPerson = await _repo.FindAsync(person.Id);

            Assert.NotNull(savedPerson);
            Assert.Equal(savedPerson.FirstName, exceptedFirstName);
            Assert.Equal(savedPerson.LastName, exceptedLastName);
            Assert.Equal(savedPerson.DateOfBirth, exceptedDateOfBirth);
            Assert.Equal(savedPerson.NationalRegistrationNumber, exceptedNationalId);
            Assert.Equal(savedPerson.DrivingLicenseType, exceptedDrivingLicenseType);
            Assert.Equal(savedPerson.Address, exceptedAdress);

        }

        [Fact]
        public async void UpdatePerson_ValidPerson_Success()
        {
            const string exceptedFirstName = "Plo";
            const string exceptedLastName = "Koon";
            DateOnly exceptedDateOfBirth = new(2001, 07, 17);
            const string exceptedNationalId = "01071700173";
            DrivingLicenseType exceptedDrivingLicenseTypes = DrivingLicenseType.C;
            Address exceptedAdress = new("Koonstreet", 20, "Brussel", 1000);

            var person = (await _repo.GetAllAsync()).Last();

            person.FirstName = exceptedFirstName;
            person.LastName = exceptedLastName;
            person.DateOfBirth = exceptedDateOfBirth;
            person.NationalRegistrationNumber = exceptedNationalId;
            person.DrivingLicenseType = exceptedDrivingLicenseTypes;
            person.Address = exceptedAdress;


            await _repo.UpdateAsync(person);
            var savedPerson = await _repo.FindAsync(person.Id);

            Assert.Equal(savedPerson.FirstName, exceptedFirstName);
            Assert.Equal(savedPerson.LastName, exceptedLastName);
            Assert.Equal(savedPerson.DateOfBirth, exceptedDateOfBirth);
            Assert.Equal(savedPerson.NationalRegistrationNumber, exceptedNationalId);
            Assert.Equal(savedPerson.DrivingLicenseType, exceptedDrivingLicenseTypes);
            Assert.Equal(savedPerson.Address, exceptedAdress);

        }

        [Fact]
        public async void DeletePerson_ValidPerson_Success()
        {
            var persons = await _repo.GetAllAsync();
            var person = persons.Last();
            _repo.Remove(person);

            var expected = persons.Count() - 1;
            var actual = (await _repo.GetAllAsync()).Count();

            Assert.Equal(actual, expected);

        }

        [Fact]
        public async void DeletePerson_InvalidPerson_ThrowsPersonRepositoryException()
        {
            var persons = await _repo.GetAllAsync();
            var person = persons.First();
            _repo.Remove(person);

            Assert.Throws<PersonRepositoryException>(() => _repo.Remove(person));

        }


        [Fact]
        public async void AddPerson_WithExistingNationalId_ThrowsPersonRepositoryException()
        {
            var persons = await _repo.GetAllAsync();

            const string firstName = "Qui-Gon";
            const string lastName = "Jinn";
            DateOnly dateOfBirth = new(1986, 02, 24);
            string nationalId = persons.Last().NationalRegistrationNumber;
            DrivingLicenseType drivingLicenseTypes = DrivingLicenseType.B;
            Address adress = new("jinnstreet", 840, "Brussel", 1000);

            var person = new Person(firstName, lastName, dateOfBirth, nationalId, drivingLicenseTypes)
            {
                Address = adress
            };

            await Assert.ThrowsAsync<PersonRepositoryException>(async () => await _repo.AddAsync(person));

        }

        [Fact]
        public async void UpdatePerson_WithExistingNationalId_ThrowsPersonRepositoryException()
        {
            var persons = await _repo.GetAllAsync();

            const string firstName = "Plo";
            const string lastName = "Koon";
            DateOnly dateOfBirth = new(1981, 05, 03);
            string nationalId = persons.Last().NationalRegistrationNumber;
            DrivingLicenseType drivingLicenseTypes = DrivingLicenseType.C;
            Address adress = new("Koonstreet", 20, "Brussel", 1000);

            var person = persons.First();

            person.FirstName = firstName;
            person.LastName = lastName;
            person.DateOfBirth = dateOfBirth;
            person.NationalRegistrationNumber = nationalId;
            person.DrivingLicenseType = drivingLicenseTypes;
            person.Address = adress;


            await Assert.ThrowsAsync<PersonRepositoryException>(async () => await _repo.UpdateAsync(person));

        }

    }
}
