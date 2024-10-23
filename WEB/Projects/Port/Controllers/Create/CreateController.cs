using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Port.Models;

namespace Port.Controllers
{
    public class CreateController : Controller
    {
        private readonly PortDContext _context;

        public CreateController(PortDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Details", "Details", new { id = order.OrderId });
            }
            return View(order);
        }
    }
}
