#nullable disable
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Exceptions;
using RestAPI.Authentication.Constants;
using System.Collections.Generic;

namespace RestAPI.Controllers
{

    [Authorize]
    [Route("/api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        /// <summary>
        /// readonly property
        /// </summary>
        private readonly ICarRepository _repo;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repo"></param>
        public CarController(ICarRepository repo)
        {
            _repo = repo;
        }
        /// <summary>
        /// Get a list of all the cars
        /// </summary>
        /// <returns>IEnumerable<Car></returns>
        // GET: api/Car
        [HttpGet(Shared.ApiRoutes.CarRoute.GetAll)]
        public async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        /// <summary>
        /// Get a list of all the cars without tracking
        /// </summary>
        /// <returns>IEnumerable<Car></returns>
        // GET: api/Car
        [HttpGet(Shared.ApiRoutes.CarRoute.GetAllStream)]
        public IAsyncEnumerable<Car> GetAllStream()
        {
            return _repo.GetAllStream();
        }

        /// <summary>
        /// Get a car by specific id
        /// </summary>
        /// <returns>car</returns>
        // GET: api/Car/
        [HttpGet(Shared.ApiRoutes.CarRoute.GetById + "{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _repo.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        /// <summary>
        /// Update a specific car
        /// </summary>
        /// <param name="car"></param>
        /// <returns>Status: OK 200</returns>
        // PUT: api/Car/
        [Authorize(Policy = UserPolicies.Manager)]
        [HttpPut(Shared.ApiRoutes.CarRoute.Update)]
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

        /// <summary>
        /// Creates a new car
        /// </summary>
        /// <param name="car"></param>
        /// <returns>Status: OK 200</returns>
        // POST: api/Car
        [Authorize(Policy = UserPolicies.Manager)]
        [HttpPost(Shared.ApiRoutes.CarRoute.Create)]
        public async Task<ActionResult<Car>> Create(Car car)
        {
            try
            {
               return Ok(await _repo.AddAsync(car));
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
        }

        /// <summary>
        /// Deletes a specific car
        /// </summary>
        /// <param name="car"></param>
        /// <returns>Status: OK 200</returns>
        // DELETE: api/Car/
        [Authorize(Policy = UserPolicies.Admin)]
        [HttpDelete(Shared.ApiRoutes.CarRoute.Delete + "{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var car = await _repo.FindAsync(id);

                if (car == null) return NotFound();

                await _repo.RemoveAsync(car);
            }
            catch (CarRepositoryException ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
