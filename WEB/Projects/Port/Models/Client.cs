using System.ComponentModel.DataAnnotations;

namespace Port.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int ClientPhone { get; set; }
        public string ClientEmail { get; set; }
        public byte[] ClientImg { get; set; }
        public DateTime Birthday { get; set; }
        public string ClientPassword { get; set; }
        public ICollection<Admin> admins { get; set; }
    }
}
