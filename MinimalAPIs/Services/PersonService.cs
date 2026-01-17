using MinimalAPIs.Models;
using MinimalAPIs.Data;
using Microsoft.EntityFrameworkCore;
using MinimalAPIs.DTOs;

namespace MinimalAPIs.Services
{

    public class PersonService(AppDbContext context) : IPersonService
    {

        public async Task<PersonResponse> AddPersonAsync(CreatePersonRequest person)
        {
             var newPerson = new Person 
                {
                    name = person.name,
                    age = person.age,
                    email = person.email
                };

                context.Persons.Add(newPerson);
                await context.SaveChangesAsync();

            return new PersonResponse
                {
                    Id = newPerson.id,
                    name = newPerson.name,
                    age = newPerson.age,
                    email = newPerson.email
                };
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var personToDelete = await context.Persons.FindAsync(id);
            if (personToDelete is null) 
                return false;

            context.Persons.Remove(personToDelete);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<PersonResponse>> GetAllPersonsAsync()
        => await context.Persons.Select(p => new PersonResponse
        {
            Id = p.id,
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
                Id = p.id,
                name = p.name,
                age = p.age,
                email = p.email
            })
            .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> UpdatePersonAsync(int id, UpdatePersonRequest person)
        {
             
            var existingPerson = await context.Persons.FindAsync(id);
            if (existingPerson is null) 
                return false;

            existingPerson.name = person.name;
            existingPerson.age = person.age;
            existingPerson.email = person.email;

            await context.SaveChangesAsync();

            return true;
        }

         
    }
}
