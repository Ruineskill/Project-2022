using Domain.Models;
using Domain.Models.Enums;
using Repository.Exceptions;
using Repository.Repositories;
using System;
using System.Linq;
using Tests.Repositories.Fixtures;
using Xunit;

namespace Tests.Repositories
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

            const string FirstName = "Qui-Gon";
            const string LastName = "Jinn";
            DateOnly DateOfBirth = new(1957, 07, 09);
            const string NationalId = "57070991264";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;
            Address Adress = new("jinnstreet", 840, "Brussel", 1000);

            var person = new Person(FirstName, LastName, DateOfBirth,
                                    NationalId, DrivingLicenseTypes,
                                    Adress, null, null);


            await _repo.AddAsync(person);
            var savedCar = await _repo.FindAsync(person.Id);

            Assert.NotNull(savedCar);

        }

        [Fact]
        public async void UpdatePerson_ValidPerson_Success()
        {
            const string ExceptedFirstName = "Plo";
            const string ExceptedLastName = "Koon";
            DateOnly ExceptedDateOfBirth = new(2001, 07, 17);
            const string ExceptedNationalId = "01071700173";
            DrivingLicenseType ExceptedDrivingLicenseTypes = DrivingLicenseType.C;
            Address ExceptedAdress = new("Koonstreet", 20, "Brussel", 1000);

            var person = (await _repo.GetAllAsync()).Last();

            person.FirstName = ExceptedFirstName;
            person.LastName = ExceptedLastName;
            person.DateOfBirth = ExceptedDateOfBirth;
            person.NationalRegistrationNumber = ExceptedNationalId;
            person.DrivingLicenseType = ExceptedDrivingLicenseTypes;
            person.Address = ExceptedAdress;


            await _repo.UpdateAsync(person);
            var savedPerson = await _repo.FindAsync(person.Id);

            Assert.Equal(savedPerson.FirstName, ExceptedFirstName);
            Assert.Equal(savedPerson.LastName, ExceptedLastName);
            Assert.Equal(savedPerson.DateOfBirth, ExceptedDateOfBirth);
            Assert.Equal(savedPerson.NationalRegistrationNumber, ExceptedNationalId);
            Assert.Equal(savedPerson.DrivingLicenseType, ExceptedDrivingLicenseTypes);
            Assert.Equal(savedPerson.Address, ExceptedAdress);

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
            const string FirstName = "Qui-Gon";
            const string LastName = "Jinn";
            DateOnly DateOfBirth = new(1986, 02, 24);
            const string NationalId = "86022402508";
            DrivingLicenseType DrivingLicenseTypes = DrivingLicenseType.B;
            Address Adress = new("jinnstreet", 840, "Brussel", 1000);

            var person = new Person(FirstName, LastName, DateOfBirth,
                                    NationalId, DrivingLicenseTypes,
                                    Adress, null, null);

            await Assert.ThrowsAsync<PersonRepositoryException>(async () => await _repo.AddAsync(person));

        }

        [Fact]
        public async void UpdatePerson_WithExistingNationalId_ThrowsPersonRepositoryException()
        {
            const string ExceptedFirstName = "Plo";
            const string ExceptedLastName = "Koon";
            DateOnly ExceptedDateOfBirth = new(1981, 05, 03);
            const string ExceptedNationalId = "81050312962";
            DrivingLicenseType ExceptedDrivingLicenseTypes = DrivingLicenseType.C;
            Address ExceptedAdress = new("Koonstreet", 20, "Brussel", 1000);

            var person = (await _repo.GetAllAsync()).First();

            person.FirstName = ExceptedFirstName;
            person.LastName = ExceptedLastName;
            person.DateOfBirth = ExceptedDateOfBirth;
            person.NationalRegistrationNumber = ExceptedNationalId;
            person.DrivingLicenseType = ExceptedDrivingLicenseTypes;
            person.Address = ExceptedAdress;


            await Assert.ThrowsAsync<PersonRepositoryException>(async () => await _repo.UpdateAsync(person));

        }

    }
}
