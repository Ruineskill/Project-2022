using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/car")]
    public class CarController : Controller
    {
        CarService carService;

        public CarController(CarService carService)
        {
            this.carService = carService;
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] Car car)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            return CreatedAtAction(nameof(AddCar), car);
        }
    }
}
