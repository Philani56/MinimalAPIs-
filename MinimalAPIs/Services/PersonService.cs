using MinimalAPIs.Models;
using MinimalAPIs.Data;
using Microsoft.EntityFrameworkCore;
using MinimalAPIs.DTOs;

namespace MinimalAPIs.Services
{

    public class PersonService(AppDbContext context) : IPersonService
    {

        public Task<PersonResponse> AddPersonAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePersonAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PersonResponse>> GetAllPersonsAsync()
        => await context.Persons.Select(p => new PersonResponse
        {
            name = p.name,
            age = p.age,
            email = p.email
        }).ToListAsync();


        public async Task<PersonResponse?> GetPersonByIdAsync(int id)
        {
            var result = await context.Persons
            .Where(p => p.id == id)
            .Select(p => new PersonResponse
            {
                name = p.name,
                age = p.age,
                email = p.email
            })
            .FirstOrDefaultAsync();

            return result;
        }

        public Task<bool> UpdatePersonAsync(int id, Person person)
        {
            throw new NotImplementedException();
        }

         
    }
}
