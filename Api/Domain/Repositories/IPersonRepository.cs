using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetById(int id);
        Task<ICollection<Person>> GetPeople();
        Task<Person> Create(Person person);
        Task Edit(Person person);
        Task Delete(Person person);
    }
}
