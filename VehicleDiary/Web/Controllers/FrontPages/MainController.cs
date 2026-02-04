using Microsoft.AspNetCore.Mvc;

namespace VehicleDiary.Web.Controllers.FrontPages
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
