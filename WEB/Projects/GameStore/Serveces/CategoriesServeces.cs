using GameStore.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Services
{

    public class CategoriesServeces : ICategoriesServeces
    {
        private readonly ApplicationDbContext _context;

        public CategoriesServeces(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectLists()
        {
                return _context.Categories
               .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
               .OrderBy(c => c.Text)
               .AsNoTracking()
               .ToList();
        }
    }
}
