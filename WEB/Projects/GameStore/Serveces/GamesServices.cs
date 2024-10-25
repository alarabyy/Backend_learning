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
                .Include(g => g.category) // تضمين العلاقة مع الفئة 'Category'
                .Include(g => g.GameDevices) // تضمين العلاقة مع 'GameDevices'
                .ThenInclude(gd => gd.Device) // تضمين الأجهزة المرتبطة
                .AsNoTracking()
                .ToList();
            return games;
        }

        public Game? GetById(int id)
        {
            return _context.Games
               .Include(g => g.category) // تضمين الفئة المرتبطة
               .Include(g => g.GameDevices) // تضمين الأجهزة المرتبطة
               .ThenInclude(gd => gd.Device) // تضمين الأجهزة المرتبطة داخل 'GameDevices'
               .AsNoTracking()
               .SingleOrDefault(g => g.Id == id);
        }

        public async Task Create(CreateGameFromViewModel model)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path = Path.Combine(_ImagePath, coverName);

            using (var stream = File.Create(path))
            {
                await model.Cover.CopyToAsync(stream);
            }

            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                categoryid = model.categoryid,
                Cover = coverName,
                GameDevices = model.SelectDevice.Select(d => new GameDevice { DeviceId = d }).ToList()
            };

            _context.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task<Game?> Update(EditGameFormViewModel model)
        {
            var game = _context.Games
                .Include(g => g.GameDevices)
                .SingleOrDefault(g => g.Id == model.Id);

            if (game is null)
                return null;

            var hasNewCover = model.Cover is not null;
            var oldCover = game.Cover;

            game.Name = model.Name;
            game.Description = model.Description;
            game.categoryid = model.categoryid;
            game.GameDevices = model.SelectDevice.Select(d => new GameDevice { DeviceId = d }).ToList();

            if (hasNewCover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }

            var effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
            {
                if (hasNewCover && oldCover != null)
                {
                    var coverPath = Path.Combine(_ImagePath, oldCover);
                    if (File.Exists(coverPath))
                    {
                        File.Delete(coverPath);
                    }
                }
                return game;
            }
            return null;
        }

        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_ImagePath, coverName);

            using (var stream = File.Create(path))
            {
                await cover.CopyToAsync(stream);
            }

            return coverName;
        }

        public bool Delete(int id)
        {
            var isDeleted = false;

            // البحث عن اللعبة المراد حذفها بناءً على الـ ID
            var game = _context.Games.Find(id);

            // إذا لم يتم العثور على اللعبة، يتم العودة بقيمة false (لم يتم الحذف)
            if (game == null)
            {
                return isDeleted;
            }

            // حذف اللعبة من قاعدة البيانات
            _context.Remove(game);

            // حفظ التغييرات في قاعدة البيانات
            var affectedRows = _context.SaveChanges();

            // إذا تم حذف صف واحد على الأقل، يتم تحديث قيمة isDeleted إلى true
            if (affectedRows > 0)
            {
                isDeleted = true;
                var cover = Path.Combine(_ImagePath , game.Cover);
                File.Delete(cover);
            }

            return isDeleted;
        }
    }
}
