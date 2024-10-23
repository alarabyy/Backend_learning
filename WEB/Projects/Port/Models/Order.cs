using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Port.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string OrderDescription { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal OrderQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderType { get; set; }
        public Byte[]? OrderImg { get; set; }
        public ICollection<Client>? clients {  get; set; } 
        public ICollection<Admin>? admins { get; set; }
    }
}
