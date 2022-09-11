using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> Created(Person person)
        {
            _dbContext.Add(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }

        public async Task Delete(Person person)
        {
            _dbContext.Remove(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(Person person)
        {
            _dbContext.Update(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await _dbContext.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Person>> GetPeople()
        {
            return await _dbContext.People.ToListAsync();
        }
    }
}
