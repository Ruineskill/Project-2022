#nullable disable
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Exceptions;
using RestAPI.Authentication.Constants;

namespace RestAPI.Controllers
{
    [Authorize]
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
        [HttpGet(Shared.ApiRoutes.PersonRoute.GetAll)]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        // GET: api/Person
        [HttpGet(Shared.ApiRoutes.PersonRoute.GetAllStream)]
        public IAsyncEnumerable<Person> GetAllStream()
        {
            return _repo.GetAllStream();
        }


        // GET: api/Person/
        [HttpGet(Shared.ApiRoutes.PersonRoute.GetById + "{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var car = await _repo.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Person/
        [Authorize(Policy = UserPolicies.Manager)]
        [HttpPut(Shared.ApiRoutes.PersonRoute.Update)]
        public async Task<IActionResult> Update(Person person)
        {
            try
            {
                await _repo.UpdateAsync(person);
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
            return Ok();
        }

        // POST: api/Person
        [Authorize(Policy = UserPolicies.Manager)]
        [HttpPost(Shared.ApiRoutes.PersonRoute.Create)]
        public async Task<ActionResult<Person>> Create(Person person)
        {
            try
            {
                return Ok(await _repo.AddAsync(person));
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


        }

        // DELETE: api/Person/
        [Authorize(Policy = UserPolicies.Admin)]
        [HttpDelete(Shared.ApiRoutes.PersonRoute.Delete + "{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var person = await _repo.FindAsync(id);

                if (person == null) return NotFound();

                _repo.Remove(person);
            }
            catch (CarRepositoryException ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok(true);
        }
    }
}
