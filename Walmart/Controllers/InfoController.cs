using Microsoft.AspNetCore.Mvc;

namespace Walmart.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Policies()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }
    }
}