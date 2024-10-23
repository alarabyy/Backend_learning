using GameStore.Data;
using GameStore.Models;
using GameStore.Services;
using GameStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Controllers
{
	public class GamesController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly ICategoriesServeces _CategoriesServeces;
		private readonly IDevicesServices _devicesServices;
		private readonly IGamesServices _gamesServices;

        public GamesController(ApplicationDbContext context , ICategoriesServeces  categoriesServeces , IDevicesServices devicesServices , IGamesServices gamesServices)
		{
			_context = context;
			_CategoriesServeces = categoriesServeces;
			_devicesServices = devicesServices;
			_gamesServices = gamesServices;	

        }

		[HttpGet]
		public IActionResult Create()
		{
			CreateGameFromViewModel viewModel = new()
			{
				categories = _context.Categories
				.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
				.OrderBy(c => c.Text)
				.ToList(),

				Devices = _context.Devices
				.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
				.OrderBy(c => c.Text)
				.ToList()

			};

			return View(viewModel);  
		}
		[HttpPost]
		[ValidateAntiForgeryToken]  /*to secure tocken*/ 
        public async Task<IActionResult> Create(CreateGameFromViewModel model)
		{
			if (!ModelState.IsValid) 
			{
				model.categories = _CategoriesServeces.GetSelectLists();
 
				model.Devices =  _devicesServices.GetSelectLists();

                return View(model);
            }

			await _gamesServices.Create(model);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            var games = _gamesServices.GetAll();
            return View(games);
        }

    }
}
