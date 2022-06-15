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
    public class FuelCardController : ControllerBase
    {
        /// <summary>
        /// readonly property
        /// </summary>
        private readonly IFuelCardRepository _repo;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repo"></param>
        public FuelCardController(IFuelCardRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get a list of all the fuelcards
        /// </summary>
        /// <returns>Enumerable<FuelCard></returns>
        // GET: api/FuelCard
        [HttpGet(Shared.ApiRoutes.FuelCardRoute.GetAll)]
        public async Task<ActionResult<IEnumerable<FuelCard>>> GetAll()
        {

            return Ok(await _repo.GetAllAsync());

        }

        /// <summary>
        /// Get a list of all the fuelcards without tracking
        /// </summary>
        /// <returns>Enumerable<FuelCard></returns>
        // GET: api/FuelCard
        [HttpGet(Shared.ApiRoutes.FuelCardRoute.GetAllStream)]
        public IAsyncEnumerable<FuelCard> GetAllStream()
        {
            return _repo.GetAllStream();
        }


        // GET: api/FuelCard/
        [HttpGet(Shared.ApiRoutes.FuelCardRoute.GetById + "{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var fc = await _repo.FindAsync(id);

            if (fc == null)
            {
                return NotFound();
            }

            return Ok(fc);
        }

        // PUT: api/FuelCard/
        [Authorize(Policy = UserPolicies.Manager)]
        [HttpPut(Shared.ApiRoutes.FuelCardRoute.Update)]
        public async Task<IActionResult> Update(FuelCard fuelCard)
        {
            try
            {
                await _repo.UpdateAsync(fuelCard);
            }
            catch (FuelCardRepositoryException ex)
            {
                if (await _repo.FindAsync(fuelCard.Id) == null)
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

        // POST: api/FuelCard
        [Authorize(Policy = UserPolicies.Manager)]
        [HttpPost(Shared.ApiRoutes.FuelCardRoute.Create)]
        public async Task<ActionResult<FuelCard>> Create(FuelCard fuelCard)
        {
            try
            {
                return Ok(await _repo.AddAsync(fuelCard));
            }
            catch (FuelCardRepositoryException ex)
            {
                if (await _repo.FindAsync(fuelCard.Id) != null)
                {
                    return Conflict();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        // DELETE: api/FuelCard/
        [Authorize(Policy = UserPolicies.Admin)]
        [HttpDelete(Shared.ApiRoutes.FuelCardRoute.Delete + "{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var fuelCard = await _repo.FindAsync(id);

                if (fuelCard == null) return NotFound();

                await _repo.RemoveAsync(fuelCard);
            }
            catch (CarRepositoryException ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
