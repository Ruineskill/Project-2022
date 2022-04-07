#nullable disable
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Exceptions;

namespace RestAPI.Controllers
{
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuelCard>>> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        // GET: api/FuelCard/
        [HttpGet("{id}")]
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
        [HttpPut]
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
        [HttpPost]
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
        [HttpDelete]
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
