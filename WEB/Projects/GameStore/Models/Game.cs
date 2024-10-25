using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(250)]
        public string Cover { get; set; }
        public int categoryid { get; set; }
        public Category category { get; set; } = default!;
        public ICollection<GameDevice> GameDevices { get; set; } = new List<GameDevice>();
    }
}