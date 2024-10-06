using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class RegesterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
