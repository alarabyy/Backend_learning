using Microsoft.EntityFrameworkCore;

namespace Port.Models
{
    /*Install-Package Microsoft.EntityFrameworkCore*/
    /*Install-Package Microsoft.EntityFrameworkCoreTools*/
    /*Install-Package Microsoft.EntityFrameworkCore.Sqlserver*/
    /*Install-Package Microsoft.EntityFrameworkCore.Design*/
public class PortDContext : DbContext
{
    public PortDContext(DbContextOptions<PortDContext> options) : base(options)
    {
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
}
  

}
