#nullable disable
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Exceptions;
using RestAPI.Authentication.Constants;


namespace Shared.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FuelCardController : ControllerBase
    {
        private readonly IFuelCardRepository _repo;

        public FuelCardController(IFuelCardRepository repo)
        {
            _repo = repo;
        }

        // GET: api/FuelCard
        [HttpGet(ApiRoutes.FuelCardRoute.GetAll)]
        public async Task<ActionResult<IEnumerable<FuelCard>>> GetAll()
        {

            return Ok(await _repo.GetAllAsync());

        }

        // GET: api/FuelCard
        [HttpGet(ApiRoutes.FuelCardRoute.GetAllStream)]
        public IAsyncEnumerable<FuelCard> GetAllStream()
        {
            return _repo.GetAllStream();
        }


        // GET: api/FuelCard/
        [HttpGet((ApiRoutes.FuelCardRoute.GetById))]
        public async Task<ActionResult<FuelCard>> Get(int id)
        {
            var fc = await _repo.FindAsync(id);

            if (fc == null)
            {
                return NotFound();
            }

            return fc;
        }

        // PUT: api/FuelCard/
        [Authorize(Policy = UserPolicies.Manager)]
        [HttpPut(ApiRoutes.FuelCardRoute.Update)]
        public async Task<ActionResult<FuelCard>> Update(FuelCard fuelCard)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(fuelCard));
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
        }

        // POST: api/FuelCard
        [Authorize(Policy = UserPolicies.Manager)]
        [HttpPost(ApiRoutes.FuelCardRoute.Create)]
        public async Task<ActionResult<FuelCard>> Create(FuelCard fuelCard)
        {
            try
            {
                await _repo.AddAsync(fuelCard);
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

            return CreatedAtAction(nameof(Get), new { id = fuelCard.Id }, fuelCard);
        }

        // DELETE: api/FuelCard/
        [Authorize(Policy = UserPolicies.Admin)]
        [HttpDelete(ApiRoutes.FuelCardRoute.Delete)]
        public async Task<IActionResult> Delete(FuelCard fuelCard)
        {
            if (await _repo.FindAsync(fuelCard.Id) == null)
            {
                return NotFound();
            }

            _repo.Remove(fuelCard);

            return Ok();
        }
    }
}
