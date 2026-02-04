using Microsoft.AspNetCore.Mvc;

namespace VehicleDiary.Web.Controllers.FrontPages
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
