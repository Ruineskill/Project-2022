using Domain.Models;
using Domain.Interfaces;
using Repository.Contexts;
using Repository.Exceptions;

namespace Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private Context ctx = new Context();

        #region Public
        public Person AddPersonRepo(Person user)
        {
            try
            {
                ctx.Persons.Add(user);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new UserRepositoryException(nameof(AddPersonRepo), ex);
            }

            return user;
        }

        public Person UpdatePersonRepo(Person user)
        {
            try
            {
                var tempUser = ctx.Persons.Find(user.Id);
                tempUser.FirstName = user.FirstName;
                tempUser.LastName = user.FirstName;
                tempUser.Address = user.Address;
                tempUser.DateOfBirth = user.DateOfBirth;
                tempUser.NationalRegistrationNumber = user.NationalRegistrationNumber;
                tempUser.DrivingLicenseTypes = user.DrivingLicenseTypes;
                tempUser.Car = user.Car;
                tempUser.FuelCard = user.FuelCard;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new UserRepositoryException(nameof(UpdatePersonRepo), ex);
            }

            return user;
        }

        public void DeletePersonRepo(Person user)
        {
            try
            {
                ctx.Persons.Remove(user);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new UserRepositoryException(nameof(DeletePersonRepo), ex);
            }

        }

        public Person GetPersonByIdRepo(int id)
        {
            try
            {
                return ctx.Persons.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new UserRepositoryException(nameof(GetPersonByIdRepo), ex);
            }
        }

        public List<Person> GetAllPersonRepo()
        {
            try
            {
                return ctx.Persons.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new UserRepositoryException(nameof(GetAllPersonRepo), ex);
            }
        }

        #endregion
    }
}
