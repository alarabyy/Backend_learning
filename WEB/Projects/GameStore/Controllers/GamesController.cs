using GameStore.Data;
using GameStore.Models;
using GameStore.Services;
using GameStore.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public GamesController(ApplicationDbContext context, ICategoriesServeces categoriesServeces, IDevicesServices devicesServices, IGamesServices gamesServices)
        {
            _context = context;
            _CategoriesServeces = categoriesServeces;
            _devicesServices = devicesServices;
            _gamesServices = gamesServices;
        }

        // Details action method remains unchanged

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFromViewModel viewModel = new()
            {
                categories = _CategoriesServeces.GetSelectLists(),
                Devices = _devicesServices.GetSelectLists()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFromViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Re-use existing model with errors
            }

            await _gamesServices.Create(model);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            var games = _gamesServices.GetAll();
            return View(games);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gamesServices.GetById(id);

            if (game == null)
            {
                return NotFound();
            }

            EditGameFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                categoryid = game.categoryid, // Use CategoryId property
                SelectDevice = game.GameDevices.Select(d => d.DeviceId).ToList(),
                categories = _CategoriesServeces.GetSelectLists(),
                Devices = _devicesServices.GetSelectLists()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Re-use existing model with errors
            }

            var game = _gamesServices.Update(model);

            if (game == null)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Home");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isdeleted = _gamesServices.Delete(id);
            return isdeleted ? Ok() : BadRequest() ;
        }
    }
}