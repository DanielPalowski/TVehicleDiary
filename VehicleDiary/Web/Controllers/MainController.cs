using Microsoft.AspNetCore.Mvc;

namespace VehicleDiary.Web.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
