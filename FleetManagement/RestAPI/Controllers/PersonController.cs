using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
