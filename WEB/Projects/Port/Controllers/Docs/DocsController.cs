using Microsoft.AspNetCore.Mvc;

namespace Port.Controllers.Docs
{
    public class DocsController : Controller
    {
        public IActionResult Docs()
        {
            return View();
        }
    }
}
