using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    public class DataHotelContext : DbContext
    {
        public DataHotelContext(DbContextOptions<DataHotelContext> options) : base(options)
        {

        }
        public DbSet<Client>  clients {  get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Admin> Admins { get; set; }   
    }
}
