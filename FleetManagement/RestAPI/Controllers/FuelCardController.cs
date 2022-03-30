using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    public class FuelCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
