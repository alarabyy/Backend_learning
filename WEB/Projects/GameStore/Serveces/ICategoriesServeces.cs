using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Services
{
    public interface ICategoriesServeces
    {
        IEnumerable<SelectListItem> GetSelectLists(); 
    }
}
