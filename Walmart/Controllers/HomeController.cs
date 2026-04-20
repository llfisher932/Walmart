using Microsoft.AspNetCore.Mvc;

namespace Walmart.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
