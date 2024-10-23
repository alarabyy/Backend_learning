using Microsoft.AspNetCore.Mvc;

namespace Port.Controllers.Signin
{
    public class SiginController : Controller
    {
        public IActionResult Sigin()
        {
            return View();
        }
    }
}
