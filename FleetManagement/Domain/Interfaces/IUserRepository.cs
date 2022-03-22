using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Person AddUserRepo(Person user);
        void DeleteUserRepo(Person user);
        List<Person> GetAllUserRepo();
        Person GetUserByIdRepo(int id);
        Person UpdateUserRepo(Person user);
    }
}