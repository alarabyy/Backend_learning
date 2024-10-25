using System.Diagnostics;
using GameStore.Data;
using GameStore.Models;
using GameStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IGamesServices _gamesServices;
        public HomeController(IGamesServices gamesServices) {
            _gamesServices =  gamesServices ;
        } 
         
        public IActionResult Index()
        {
            string msg = "hello world";
            int temp = 10;

            ViewData["TEMP"]=temp;
            ViewData["MSG"] = msg;


            var games = _gamesServices.GetAll();
            return View(games);
        }

    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
