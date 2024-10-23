using GameStore.Data;
using GameStore.Models;
using GameStore.Services;
using GameStore.ViewModel;
using GameStore.Sitting;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Services
{
    public class GamesServices : IGamesServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _ImagePath;

        public GamesServices(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _ImagePath = $"{_webHostEnvironment.WebRootPath}{FileSitting.ImagePath}";
        }

		public IEnumerable<Game> GetAll()
		{
            var games = _context.Games
                .Include(G => G.category)
                .Include(G => G.devices)
                .ThenInclude(G => G.device)
                .AsNoTracking()
                .ToList();
            return games;
		}

		public async Task Create(CreateGameFromViewModel model)
        {
            // إنشاء اسم الغلاف
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";

            // تحديد المسار الكامل للصورة
            var path = Path.Combine(_ImagePath, CoverName);

            // نسخ الصورة إلى المسار المحدد
            using var stream = File.Create(path);
            await model.Cover.CopyToAsync(stream);
            stream.Dispose();  // إغلاق الـ stream بعد الاستخدام

            // إنشاء الكائن الجديد من اللعبة
            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                categoryid = model.categoryid,
                Cover = CoverName,
                devices = model.SelectDevice.Select(d => new GameDevice { Deviceid = d }).ToList()
            };

            // إضافة اللعبة إلى قاعدة البيانات
            _context.Add(game);
            await _context.SaveChangesAsync();  // استخدام SaveChangesAsync
        }


	}
}
