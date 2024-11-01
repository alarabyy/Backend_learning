using System.ComponentModel.DataAnnotations;

namespace Port.Models
{
    public class Signin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
    }
}
