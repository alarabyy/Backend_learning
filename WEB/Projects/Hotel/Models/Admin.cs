using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPhone { get; set; }
        public string AdminPassword { get; set; }
        public string AdminConfirmPassword { get; set; }
        public ICollection<Rooms> Rooms { get; set; }





    }
}
