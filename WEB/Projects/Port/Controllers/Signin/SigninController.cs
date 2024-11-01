using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Port.Models;

namespace Port.Controllers
{
    public class SigninController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SigninController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(Signin signin)
        {
            if (ModelState.IsValid)
            {
                _context.signins.Add(signin);
                _context.SaveChanges();

                // تعديل هنا لاستخدام signin.Id
                return RedirectToAction("Login", "Login", new { id = signin.Id });
            }

            return View(signin);
        }
    }
}
