using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataHotelContext _context;
        public HomeController(DataHotelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


     
    }
}
