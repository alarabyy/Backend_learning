namespace Ports_and_ships.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double size  { get; set; }
        public double price { get; set; }
        public byte[] img { get; set; }
        public ICollection<Client> clients { get; set; }
        public ICollection<Ship> shipS { get; set; }
    }
}
