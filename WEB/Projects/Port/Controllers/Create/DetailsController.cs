using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Port.Models;

public class DetailsController : Controller
{
    private readonly ApplicationDbContext _context;

    public DetailsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return View("Erorr");
        }
        else
        {
            Order order = _context.Orders.FirstOrDefault(e => e.OrderId == id);
            return View("Details", order);

        }

        //  var orderDetail = _context.Orders.Find();

        //if (orderDetail == null)
        //{
        //    return View("NotFound");
        //}

    }
}
