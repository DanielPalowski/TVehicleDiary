using Microsoft.AspNetCore.Mvc;

namespace VehicleDiary.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
