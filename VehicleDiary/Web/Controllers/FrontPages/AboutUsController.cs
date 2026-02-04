using Microsoft.AspNetCore.Mvc;

namespace VehicleDiary.Web.Controllers.FrontPages
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
