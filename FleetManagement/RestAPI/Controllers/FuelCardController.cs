#nullable disable
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
        [HttpGet((ApiRoutes.FuelCardRoute.GetById + "{id}"))]
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
        [HttpPut(ApiRoutes.FuelCardRoute.Update)]
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
        [HttpPost(ApiRoutes.FuelCardRoute.Create)]
        public async Task<IActionResult> Create(FuelCard fuelCard)
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
            return Ok();
        }

        // DELETE: api/FuelCard/
        [Authorize(Policy = UserPolicies.Admin)]
        [HttpDelete(ApiRoutes.FuelCardRoute.Delete + "{id}")]
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
