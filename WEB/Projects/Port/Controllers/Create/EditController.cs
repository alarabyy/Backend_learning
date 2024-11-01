using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Port.Models;

namespace Port.Controllers
{
    public class EditController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EditController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================= Edit (GET) =================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // ================= Edit (POST) =================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    _context.SaveChanges();
                    return RedirectToAction("AllData", "AllData"); // تأكد من أن اسم الأكشن/الكنترولر صحيحين
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Please try again.");
                }
            }
            return View(order);
        }
    }
}
