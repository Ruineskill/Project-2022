﻿#nullable disable
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Exceptions;
using Shared.Authentication.Constants;

namespace Shared.Controllers
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
        [HttpGet(ApiRoutes.PersonRoute.GetAll)]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        // GET: api/Person
        [HttpGet(ApiRoutes.PersonRoute.GetAllStream)]
        public IAsyncEnumerable<Person> GetAllStream()
        {
            return _repo.GetAllStream();
        }


        // GET: api/Person/
        [HttpGet(ApiRoutes.PersonRoute.GetById + "{id}")]
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
        [HttpPut(ApiRoutes.PersonRoute.Update)]
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
        [HttpPost(ApiRoutes.PersonRoute.Create)]
        public async Task<IActionResult> Create(Person person)
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

            return Ok();
        }

        // DELETE: api/Person/
        [Authorize(Policy = UserPolicies.Admin)]
        [HttpDelete(ApiRoutes.PersonRoute.Delete + "{id}")]
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
