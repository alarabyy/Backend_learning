using Microsoft.AspNetCore.Mvc;

namespace Port.Controllers.Profile
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
