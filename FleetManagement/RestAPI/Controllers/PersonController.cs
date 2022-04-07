#nullable disable
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Exceptions;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _repo;

        public PersonController(IPersonRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        // GET: api/Person/
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var car = await _repo.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Person/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(Person person)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(person));
            }
            catch (PersonRepositoryException ex)
            {
                if (await _repo.FindAsync(person.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        // POST: api/Person
        [HttpPost]
        public async Task<ActionResult<Person>> Create(Person person)
        {
            try
            {
                await _repo.AddAsync(person);
            }
            catch (PersonRepositoryException ex)
            {
                if (await _repo.FindAsync(person.Id) != null)
                {
                    return Conflict();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        // DELETE: api/Person/
        [HttpDelete]
        public async Task<IActionResult> DeletePerson(Person person)
        {
            if (await _repo.FindAsync(person.Id) == null)
            {
                return NotFound();
            }

            _repo.Remove(person);

            return Ok();
        }       
    }
}
