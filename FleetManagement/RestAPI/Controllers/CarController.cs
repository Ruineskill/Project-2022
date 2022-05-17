#nullable disable
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Exceptions;
using Shared.Authentication.Constants;
using System.Collections.Generic;

namespace Shared.Controllers
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
        [HttpGet(ApiRoutes.CarRoute.GetAll)]
        public async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        // GET: api/Car
        [HttpGet(ApiRoutes.CarRoute.GetAllStream)]
        public IAsyncEnumerable<Car> GetAllStream()
        {
            return _repo.GetAllStream();
        }

        // GET: api/Car/
        [HttpGet(ApiRoutes.CarRoute.GetById + "{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _repo.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Car/
        [Authorize(Policy = UserPolicies.Manager)]
        [HttpPut(ApiRoutes.CarRoute.Update)]
        public async Task<IActionResult> Update(Car car)
        {
            try
            {
                await _repo.UpdateAsync(car);
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

            return Ok();
        }

        // POST: api/Car
        [Authorize(Policy = UserPolicies.Manager)]
        [HttpPost(ApiRoutes.CarRoute.Create)]
        public async Task<IActionResult> Create(Car car)
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

            return Ok();
        }

        // DELETE: api/Car/
        [Authorize(Policy = UserPolicies.Admin)]
        [HttpDelete(ApiRoutes.CarRoute.Delete + "{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var car = await _repo.FindAsync(id);

                if (car == null) return NotFound();

                _repo.Remove(car);
            }
            catch (CarRepositoryException ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
