using Microsoft.AspNetCore.Mvc;

namespace VehicleDiary.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
