using Microsoft.AspNetCore.Mvc;

namespace Walmart.Controllers
{
    public class AboutController : Controller
    {
        // GET: /About/OurCompany
        public IActionResult OurCompany()
        {
            // The view file is located at Views/Shared/ourcompany.cshtml
            return View("ourcompany");
        }
    }
}
 