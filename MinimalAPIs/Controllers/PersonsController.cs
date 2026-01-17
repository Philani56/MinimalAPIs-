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
    }

}

