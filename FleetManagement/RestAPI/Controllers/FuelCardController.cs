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
        private readonly IFuelCardRepository _repo;

        public FuelCardController(IFuelCardRepository repo)
        {
            _repo = repo;
        }

        // GET: api/FuelCard
        [HttpGet(Shared.ApiRoutes.FuelCardRoute.GetAll)]
        public async Task<ActionResult<IEnumerable<FuelCard>>> GetAll()
        {

            return Ok(await _repo.GetAllAsync());

        }

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

                _repo.Remove(fuelCard);
            }
            catch (CarRepositoryException ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
