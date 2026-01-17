using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPIs.DTOs;
using MinimalAPIs.Models;
using MinimalAPIs.Services;

namespace MinimalAPIs.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class PersonsController(IPersonService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PersonResponse>>> GetPersons()
        => Ok(await service.GetAllPersonsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> GetPerson(int id)
        {
            var person = await service.GetPersonByIdAsync(id);
            if (person is null)
            {
                return NotFound("Person with the given Id was not found.");
            }
            return Ok(person);
        }
    


        [HttpPost]
        public async Task<ActionResult<PersonResponse>> CreatePerson(CreatePersonRequest request)
        {
            var createdPerson = await service.AddPersonAsync(request);
            return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.Id }, createdPerson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePerson(int id, UpdatePersonRequest request)
        {
            var updatedPerson = await service.UpdatePersonAsync(id, request);
            return updatedPerson ? NoContent() : NotFound("Person with the given Id was not found.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var deletedPerson = await service.DeletePersonAsync(id);
            return deletedPerson ? NoContent() : NotFound("Person with the given Id was not found.");
        }









    }
}

