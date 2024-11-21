using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Port.Models
{
    public class Order
    {
        [Key]

        public int OrderId { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        [UniqName]
        [Remote(action:"Create",controller: "Create")]
        public string OrderName { get; set; }
        [Required]
        [MaxLength(300)]
        [MinLength(3)]

        public string? OrderDescription { get; set; } 
        public decimal OrderPrice { get; set; }
        public decimal OrderQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string OrderType { get; set; }
        public Byte[]? OrderImg { get; set; }
        public ICollection<Admin>? admins { get; set; }
    }
}
