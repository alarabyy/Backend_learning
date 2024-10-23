using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Icon { get; set; }
    }
}
