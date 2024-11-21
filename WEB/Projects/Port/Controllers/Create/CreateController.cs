using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Port.Models;

namespace Port.Controllers
{
    public class CreateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreateController(ApplicationDbContext context)
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
                var silverOrder = new Order
                {
                    OrderId = order.OrderId,
                    OrderName = order.OrderName,
                    OrderQuantity = order.OrderQuantity,
                    OrderPrice = order.OrderPrice,
                    OrderType = order.OrderType,
                    OrderDescription = order.OrderDescription ?? "No Description Provided"
                };

                _context.Orders.Add(silverOrder);
                _context.SaveChanges();

                return RedirectToAction("Details", "Details", new { id = silverOrder.OrderId });
            }

            return View(order);
        }

    }
}
