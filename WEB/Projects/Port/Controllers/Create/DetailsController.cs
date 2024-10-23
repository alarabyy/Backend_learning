using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Port.Models;

public class DetailsController : Controller
{
    private readonly PortDContext _context;

    public DetailsController(PortDContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return View("NotFound");
        }

        var orderDetail = _context.Orders.Find(id);

        if (orderDetail == null)
        {
            return View("NotFound");
        }

        return View(orderDetail);
    }
}
