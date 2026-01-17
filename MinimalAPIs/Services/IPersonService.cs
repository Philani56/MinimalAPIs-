using MinimalAPIs.DTOs;
using MinimalAPIs.Models;

namespace MinimalAPIs.Services
{
    public interface IPersonService
    {
        Task<List<PersonResponse>> GetAllPersonsAsync();

        Task<PersonResponse?> GetPersonByIdAsync(int id);
        Task<PersonResponse> AddPersonAsync(Person person);
        Task<bool> UpdatePersonAsync(int id, Person person);
        Task<bool> DeletePersonAsync(int id);
    }
}
