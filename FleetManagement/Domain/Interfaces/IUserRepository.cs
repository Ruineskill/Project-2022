using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User AddUserRepo(User user);
        void DeleteUserRepo(User user);
        List<User> GetAllUserRepo();
        User GetUserByIdRepo(int id);
        User UpdateUserRepo(User user);
    }
}