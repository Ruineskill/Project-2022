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
    public class CarRepoTest : IClassFixture<CarFixture>
    {
        private readonly CarRepository _repo;

        public CarRepoTest(CarFixture fixture)
        {
            var context = fixture.CreateContext();
            _repo = new CarRepository(context);
        }

        [Fact]
        public async void AddCar_ValidCar_Success()
        {

            const string ChassisNumber = "1GYFK63817R340248";
            const string LicensePlate = "1-ABC-265";
            const string Brand = "Volvo";
            const string Model = "XC40";
            CarType Type = CarType.Van;
            const string Color = "Green";
            FuelType FuelType = FuelType.Benzine;
            const int DoorCount = 4;

            var car = new Car(Brand, Model, ChassisNumber, LicensePlate, FuelType, Type);
            car.Color = Color;
            car.NumberOfDoors = DoorCount;

            await _repo.AddAsync(car);
            var savedCar = await _repo.FindAsync(car.Id);
            Assert.NotNull(savedCar);

        }

        [Fact]
        public async void UpdateCar_ValidCar_Success()
        {
            const string ExceptedChassisNumber = "1GTN1TEX1DZ200378";
            const string ExceptedLicensePlate = "1-ABC-264";
            const string ExceptedBrand = "Ford";
            const string ExceptedModel = "BS";
            CarType ExceptedType = CarType.Van;
            const string ExceptedColor = "Blue";
            FuelType ExceptedFuelType = FuelType.Diesel;
            const int ExceptedDoorCount = 4;

            var car = (await _repo.GetAllAsync()).First();

            car.ChassisNumber = ExceptedChassisNumber;
            car.LicensePlate = ExceptedLicensePlate;
            car.Brand = ExceptedBrand;
            car.Model = ExceptedModel;
            car.Type = ExceptedType;
            car.Color = ExceptedColor;
            car.FuelType = ExceptedFuelType;
            car.NumberOfDoors = ExceptedDoorCount;

            await _repo.UpdateAsync(car);
            var savedCar = await _repo.FindAsync(car.Id);

            Assert.Equal(savedCar.ChassisNumber, ExceptedChassisNumber);
            Assert.Equal(savedCar.LicensePlate, ExceptedLicensePlate);
            Assert.Equal(savedCar.Brand, ExceptedBrand);
            Assert.Equal(savedCar.Model, ExceptedModel);
            Assert.Equal(savedCar.Type, ExceptedType);
            Assert.Equal(savedCar.Color, ExceptedColor);
            Assert.Equal(savedCar.FuelType, ExceptedFuelType);
            Assert.Equal(savedCar.NumberOfDoors, ExceptedDoorCount);

        }

        [Fact]
        public async void DeleteCar_ValidCar_Success()
        {



            var cars = await _repo.GetAllAsync();
            var car = cars.First();
            _repo.Remove(car);


            var expected = cars.Count() - 1;
            var actual = (await _repo.GetAllAsync()).Count();

            Assert.Equal(actual, expected);

        }

        [Fact]
        public async void DeleteCar_InvalidCar_ThrowsCarRepositoryException()
        {

            var cars = await _repo.GetAllAsync();
            var car = cars.First();
            _repo.Remove(car);

            Assert.Throws<CarRepositoryException>(() => _repo.Remove(car));

        }


        [Fact]
        public async void AddCar_WithExistingVIN_ThrowsCarRepositoryException()
        {

            var cars = await _repo.GetAllAsync();

            string ChassisNumber = cars.Last().ChassisNumber;
            const string LicensePlate = "1-ABC-265";
            const string Brand = "Mercedes";
            const string Model = "Classe A";
            CarType Type = CarType.Van;
            const string Color = "Green";
            FuelType FuelType = FuelType.Benzine;
            const int DoorCount = 4;

            var car = new Car(Brand, Model, ChassisNumber, LicensePlate, FuelType, Type);
            car.Color = Color;
            car.NumberOfDoors = DoorCount;

            await Assert.ThrowsAsync<CarRepositoryException>(async () => await _repo.AddAsync(car));

        }

        [Fact]
        public async void AddCar_WithExistingLicensePlate_ThrowsCarRepositoryException()
        {

            var cars = await _repo.GetAllAsync();
            const string ChassisNumber = "5GZCZ43D13S812715";
            string LicensePlate = cars.Last().LicensePlate;
            const string Brand = "Volkswagen";
            const string Model = "Tiguan";
            CarType Type = CarType.Van;
            const string Color = "Green";
            FuelType FuelType = FuelType.Benzine;
            const int DoorCount = 4;

            var car = new Car(Brand, Model, ChassisNumber, LicensePlate, FuelType, Type);
            car.Color = Color;
            car.NumberOfDoors = DoorCount;

            await Assert.ThrowsAsync<CarRepositoryException>(async () => await _repo.AddAsync(car));

        }

        [Fact]
        public async void UpdateCar_WithExistingVIN_ThrowsCarRepositoryException()
        {
            var cars = await _repo.GetAllAsync();

            string ChassisNumber = cars.Last().ChassisNumber;
            const string LicensePlate = "1-ABC-265";
            const string Brand = "Volkswagen";
            const string Model = "Tiguan";
            CarType Type = CarType.Coupe;
            const string Color = "Purple";
            FuelType FuelType = FuelType.HybridDiesel;
            const int DoorCount = 4;

            var car = cars.First();

            car.ChassisNumber = ChassisNumber;
            car.LicensePlate = LicensePlate;
            car.Brand = Brand;
            car.Model = Model;
            car.Type = Type;
            car.Color = Color;
            car.FuelType = FuelType;
            car.NumberOfDoors = DoorCount;



            await Assert.ThrowsAsync<CarRepositoryException>(async () => await _repo.UpdateAsync(car));

        }

        [Fact]
        public async void UpdateCar_WithExistingLicensePlate_ThrowsCarRepositoryException()
        {
            var cars = await _repo.GetAllAsync();
            const string ChassisNumber = "5GZCZ43D13S812715";
            string LicensePlate = cars.Last().LicensePlate;
            const string Brand = "Volvo";
            const string Model = "XC40";
            CarType Type = CarType.Van;
            const string Color = "Green";
            FuelType FuelType = FuelType.Benzine;
            const int DoorCount = 4;

            var car = cars.First();

            car.ChassisNumber = ChassisNumber;
            car.LicensePlate = LicensePlate;
            car.Brand = Brand;
            car.Model = Model;
            car.Type = Type;
            car.Color = Color;
            car.FuelType = FuelType;
            car.NumberOfDoors = DoorCount;

            await Assert.ThrowsAsync<CarRepositoryException>(async () => await _repo.UpdateAsync(car));

        }


    }
}
