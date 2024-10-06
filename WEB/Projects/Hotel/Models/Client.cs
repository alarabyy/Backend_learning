using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public int age { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public string? Address { get; set; }
        public int? Password { get; set; }
        public int? ConfirmPassword { get; set; }
    }
}
