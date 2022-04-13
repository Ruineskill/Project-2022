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
using Tests.Repositories.Fixtures;
using Repository.Exceptions;

namespace Tests.Repositories
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


            long cardNumber = 87976874547;          
            int pinCode = 8889;
            DateOnly expirationDate = new(2025, 02, 15);
            List<FuelType> usableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            var fuelCard = new FuelCard(cardNumber, expirationDate, pinCode, usableFuelTypes, null);

            await _repo.AddAsync(fuelCard);
            var savedCar = await _repo.FindAsync(fuelCard.Id);

            Assert.NotNull(savedCar);

        }

        [Fact]
        public async void UpdateFuelCard_ValidFuelCard_Success()
        {


            long ExceptedCardNumber = 87976872547;
            int ExceptedPinCode = 8889;
            DateOnly ExceptedExpirationDate = new(2025, 02, 15);
            List<FuelType> ExceptedUsableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };


            var fuelCard = (await _repo.GetAllAsync()).First();

            fuelCard.CardNumber = ExceptedCardNumber;
            fuelCard.ExpirationDate = ExceptedExpirationDate;
            fuelCard.PinCode = ExceptedPinCode;
            fuelCard.UsableFuelTypes = ExceptedUsableFuelTypes;

             await _repo.UpdateAsync(fuelCard);

            var savedFuelCard = await _repo.FindAsync(fuelCard.Id);

            Assert.Equal(savedFuelCard.CardNumber, ExceptedCardNumber);
            Assert.Equal(savedFuelCard.ExpirationDate, ExceptedExpirationDate);
            Assert.Equal(savedFuelCard.PinCode, ExceptedPinCode);
            Assert.True(Enumerable.SequenceEqual(savedFuelCard.UsableFuelTypes, ExceptedUsableFuelTypes));
          
        }

        [Fact]
        public async void DeleteFuelCard_ValidFuelCard_Success()
        {


            var fuelCards = await _repo.GetAllAsync();
            var fuelCard = fuelCards.First();
            _repo.Remove(fuelCard);


            var expected = fuelCards.Count() - 1;
            var actual = (await _repo.GetAllAsync()).Count();

            Assert.Equal(actual, expected);

        }

        [Fact]
        public async void DeleteFuelCard_InvalidFuelCard_ThrowsFuelCardRepositoryException()
        {


            var fuelCards = await _repo.GetAllAsync();
            var fuelCard = fuelCards.First();
            _repo.Remove(fuelCard);

             Assert.Throws<FuelCardRepositoryException>(() => _repo.Remove(fuelCard));

        }

        [Fact]
        public async void AddFuelCard_WithExistingCard_ThrowsFuelCardRepositoryException()
        {


            long cardNumber = 46794775821745828;
            int pinCode = 8889;
            DateOnly expirationDate = new(2025, 02, 15);
            List<FuelType> usableFuelTypes = new() { FuelType.Diesel, FuelType.Benzine };

            var fuelCard = new FuelCard(cardNumber, expirationDate, pinCode, usableFuelTypes, null);

            await Assert.ThrowsAsync<FuelCardRepositoryException>(async () => await _repo.AddAsync(fuelCard));

        }


        [Fact]
        public async void UpdateFuelCard_WithExistingCard_ThrowsFuelCardRepositoryException()
        {


            long cardNumber = 38294475827545826;
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
