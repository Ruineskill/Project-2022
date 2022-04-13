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
    [Route("/api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repo;

        public CarController(ICarRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        // GET: api/Car/
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _repo.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Car/
        [Authorize(Roles = UserRoles.ManagerAndAdmin)]
        [HttpPut]
        public async Task<ActionResult<Car>> Update(Car car)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(car));
            }
            catch (CarRepositoryException ex)
            {
                if (await _repo.FindAsync(car.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        // POST: api/Car
        [Authorize(Roles = UserRoles.ManagerAndAdmin)]
        [HttpPost]
        public async Task<ActionResult<Car>> Create(Car car)
        {
            try
            {
                await _repo.AddAsync(car);
            }
            catch (CarRepositoryException ex)
            {
                if (await _repo.FindAsync(car.Id) != null)
                {
                    return Conflict();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }

            return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
        }

        // DELETE: api/Car/
        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(Car car)
        {
            if (await _repo.FindAsync(car.Id) == null)
            {
                return NotFound();
            }

            _repo.Remove(car);

            return Ok();
        }
    }
}
