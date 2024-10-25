using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModel
{
    public class EditGameFormViewModel
    {
        internal List<int> SelectedDevices;

        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int categoryid { get; set; }

        public IEnumerable<SelectListItem> categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Supported Devices")]
        public List<int> SelectDevice { get; set; } = default!;

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [Display(Name = "Choose your Cover")]
        public IFormFile? Cover { get; set; }
    }
}
