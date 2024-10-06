using Microsoft.EntityFrameworkCore;

//Install - Package Microsoft.EntityFrameworkCore
//Install - Package Microsoft.EntityFrameworkCore.SqlServer
//Install - Package Microsoft.EntityFrameworkCore.Design
//Install - Package Microsoft.EntityFrameworkCore.Tools



namespace Ports_and_ships.Models
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options)
     : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Ship> Ships { get; set; }
    }
}
