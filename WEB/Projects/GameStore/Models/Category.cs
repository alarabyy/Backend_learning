using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Game> games { get; set; } = new List<Game>();
    }
}
