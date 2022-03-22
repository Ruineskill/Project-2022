using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPersonRepository
    {
        Person AddPersonRepo(Person user);
        void DeletePersonRepo(Person user);
        List<Person> GetAllPersonRepo();
        Person GetPersonByIdRepo(int id);
        Person UpdatePersonRepo(Person user);
    }
}