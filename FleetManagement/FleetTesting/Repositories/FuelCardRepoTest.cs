using Xunit;
using Domain.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Enums;
using Repository.Exceptions;
using UnitTest.Repositories.Fixtures;

namespace UnitTest.Repositories
{
    [Collection("RepoCollection")]
    public class FuelCardRepoTest : IClassFixture<FuelCardFixture>
    {
        private readonly FuelCardRepository _repo;

        public FuelCardRepoTest(FuelCardFixture fixture)
        {
            var context = fixture.CreateContext();
            _repo = new FuelCardRepository(context);
        }

        [Fact]
        public async void AddFuelCard_ValidFuelCard_Success()
        {


            long exceptedCardNumber = 87976874547;
            int exceptedPinCode = 8889;
            DateOnly exceptedExpirationDate = new(2025, 02, 15);
            List<FuelType> exceptedUsableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            var fuelCard = new FuelCard(exceptedCardNumber, exceptedExpirationDate, exceptedPinCode, exceptedUsableFuelTypes);

            await _repo.AddAsync(fuelCard);
            var savedCar = await _repo.FindAsync(fuelCard.Id);

            Assert.NotNull(savedCar);

        }

        [Fact]
        public async void UpdateFuelCard_ValidFuelCard_Success()
        {


            long exceptedCardNumber = 87976845547;
            int exceptedPinCode = 8889;
            DateOnly exceptedExpirationDate = new(2025, 02, 15);
            List<FuelType> exceptedUsableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };


            var fuelCard = (await _repo.GetAllAsync()).First();

            fuelCard.CardNumber = exceptedCardNumber;
            fuelCard.ExpirationDate = exceptedExpirationDate;
            fuelCard.PinCode = exceptedPinCode;
            fuelCard.UsableFuelTypes = exceptedUsableFuelTypes;

            await _repo.UpdateAsync(fuelCard);

            var savedFuelCard = await _repo.FindAsync(fuelCard.Id);

            Assert.Equal(savedFuelCard.CardNumber, exceptedCardNumber);
            Assert.Equal(savedFuelCard.ExpirationDate, exceptedExpirationDate);
            Assert.Equal(savedFuelCard.PinCode, exceptedPinCode);
            Assert.True(savedFuelCard.UsableFuelTypes.SequenceEqual(exceptedUsableFuelTypes));

        }

        [Fact]
        public async void DeleteFuelCard_ValidFuelCard_Success()
        {

            var fuelCards = await _repo.GetAllAsync();
            var fuelCard = fuelCards.First();
            await _repo.RemoveAsync(fuelCard);


            var expected = fuelCards.Count() - 1;
            var actual = (await _repo.GetAllAsync()).Count();

            Assert.Equal(actual, expected);

        }

        [Fact]
        public async void DeleteFuelCard_InvalidFuelCard_ThrowsFuelCardRepositoryException()
        {

            var fuelCards = await _repo.GetAllAsync();
            var fuelCard = fuelCards.First();
            await _repo.RemoveAsync(fuelCard);

            await Assert.ThrowsAsync<FuelCardRepositoryException>(async () => await _repo.RemoveAsync(fuelCard));

        }

        [Fact]
        public async void AddFuelCard_WithExistingCard_ThrowsFuelCardRepositoryException()
        {

            var fuelCards = await _repo.GetAllAsync();

            long cardNumber = fuelCards.Last().CardNumber;
            int pinCode = 8889;
            DateOnly expirationDate = new(2025, 02, 15);
            List<FuelType> usableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            var fuelCard = new FuelCard(cardNumber, expirationDate, pinCode, usableFuelTypes);

            await Assert.ThrowsAsync<FuelCardRepositoryException>(async () => await _repo.AddAsync(fuelCard));

        }


        [Fact]
        public async void UpdateFuelCard_WithExistingCard_ThrowsFuelCardRepositoryException()
        {
            var fuelCards = await _repo.GetAllAsync();

            long cardNumber = fuelCards.Last().CardNumber;
            int pinCode = 8889;
            DateOnly expirationDate = new(2025, 02, 15);
            List<FuelType> usableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            var fuelCard = (await _repo.GetAllAsync()).First();

            fuelCard.CardNumber = cardNumber;
            fuelCard.ExpirationDate = expirationDate;
            fuelCard.PinCode = pinCode;
            fuelCard.UsableFuelTypes = usableFuelTypes;



            await Assert.ThrowsAsync<FuelCardRepositoryException>(async () => await _repo.UpdateAsync(fuelCard));

        }

    }
}
