using Microsoft.AspNetCore.Mvc;

namespace VehicleDiary.Web.Controllers.FrontPages
{
    public class TermsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
