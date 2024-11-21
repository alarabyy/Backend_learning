using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Port.Controllers
{
    public class AllDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllDataController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public IActionResult AllData()
        {
            var orders = _context.Orders.ToList();
            return View("AllData", orders );
        }
        //******************************************************************
        //******************************************************************
        //******************************************************************


    }
}
