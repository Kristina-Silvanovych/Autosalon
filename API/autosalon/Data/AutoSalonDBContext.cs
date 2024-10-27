using autosalon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace autosalon.Data
{
    public class AutoSalonDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public AutoSalonDBContext(DbContextOptions options) : base(options)
        {      
        }
        public class EFDBContextFactory : IDesignTimeDbContextFactory<AutoSalonDBContext>
        {
            public AutoSalonDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AutoSalonDBContext>();
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AutoSalonDB;Integrated Security=True;TrustServerCertificate=True");
                return new AutoSalonDBContext(optionsBuilder.Options);
            }
        }
    }
}
