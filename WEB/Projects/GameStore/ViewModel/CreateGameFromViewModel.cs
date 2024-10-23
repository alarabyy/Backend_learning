using System.ComponentModel.DataAnnotations;
using GameStore.attribute;
using GameStore.Sitting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.ViewModel
{
	public class CreateGameFromViewModel
	{
		[MaxLength(250)]
		public string Name { get; set; } = string.Empty;

		[Display(Name = "Category")]
		public int categoryid { get; set; }

		public IEnumerable<SelectListItem> categories { get; set; } = Enumerable.Empty<SelectListItem>();

		[Display(Name ="Supported Devices")]
		public List<int> SelectDevice { get; set; } = default!;

		public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

		[MaxLength(2500)]
		public string Description { get; set; } = string.Empty;
		[Display(Name ="Choose your Cover")]
		public IFormFile Cover { get; set; }
	} 
}
