using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Port.Models;

namespace Port.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int? id)
        {
            var order = _context.Orders.FirstOrDefault(e => e.OrderId == id);

            if (!ModelState.IsValid)
            {
                return View("Error"); // This returns the Error.cshtml view
            }

            return View(order);
        }

        public IActionResult Error() 
        { 
          return View("Error");
        }
    }
}
