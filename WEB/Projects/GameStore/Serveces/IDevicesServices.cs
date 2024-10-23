using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Services
{
    public interface IDevicesServices
    {
        IEnumerable<SelectListItem> GetSelectLists();
    }
}
