using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICarRepository
    {
        Car AddCarRepo(Car vehicle);
        void DeleteCarRepo(Car vehicle);
        List<Car> GetAllCarRepo();
        Car GetCarByIdRepo(int id);
        Car UpdateCarRepo(Car vehicle);
    }
}