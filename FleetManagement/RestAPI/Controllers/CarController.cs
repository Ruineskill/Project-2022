#nullable disable
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Exceptions;

namespace RestAPI.Controllers
{
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
