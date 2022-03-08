using Domain.Models;
using Domain.Interfaces;
using Repository.Contexts;
using Repository.Exceptions;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Context ctx = new Context();

        #region Public
        public User AddUserRepo(User user)
        {
            try
            {
                ctx.User.Add(user);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new UserRepositoryException(nameof(AddUserRepo), ex);
            }

            return user;
        }

        public User UpdateUserRepo(User user)
        {
            try
            {
                var tempUser = ctx.User.Find(user.Id);
                tempUser.Name = user.Name;
                tempUser.FirstName = user.FirstName;
                tempUser.Street = user.Street;
                tempUser.HouseNumber = user.HouseNumber;
                tempUser.City = user.City;
                tempUser.PostalCode = user.PostalCode;
                tempUser.DayOfBirth = user.DayOfBirth;
                tempUser.NationRegistrationNumber = user.NationRegistrationNumber;
                tempUser.DriversLicenseType = user.DriversLicenseType;
                tempUser.Vehicle = user.Vehicle;
                tempUser.FuelCard = user.FuelCard;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new UserRepositoryException(nameof(UpdateUserRepo), ex);
            }

            return user;
        }

        public void DeleteUserRepo(User user)
        {
            try
            {
                ctx.User.Remove(user);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new UserRepositoryException(nameof(DeleteUserRepo), ex);
            }

        }

        public User GetUserByIdRepo(int id)
        {
            try
            {
                return ctx.User.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new UserRepositoryException(nameof(GetUserByIdRepo), ex);
            }
        }

        public List<User> GetAllUserRepo()
        {
            try
            {
                return ctx.User.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new UserRepositoryException(nameof(GetAllUserRepo), ex);
            }
        }

        #endregion
    }
}
