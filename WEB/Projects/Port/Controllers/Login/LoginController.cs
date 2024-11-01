using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Port.Models; 
using System.Linq;

namespace Port.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                // تحقق من المستخدم في قاعدة البيانات
                var user = _context.signins
                    .FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    TempData["Message"] = "Login successful!";
                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View();
        }
    }
}
