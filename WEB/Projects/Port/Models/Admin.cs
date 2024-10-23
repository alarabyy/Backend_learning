using System.ComponentModel.DataAnnotations;

namespace Port.Models
{
    public class Admin
    {
        [Key]
        public int AdmintID { get; set; }
        public string AdminName { get; set; }
        public int AdminPhone { get; set; }
        public string AdminEmail { get; set; }
        public byte[] AdminImg { get; set; }
        public DateTime Birthday { get; set; }
        public string AdminPassword { get; set; }

    }
}
