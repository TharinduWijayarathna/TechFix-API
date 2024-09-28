using Microsoft.EntityFrameworkCore;
using CompanyAPI.Model;
namespace CompanyAPI.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(
            DbContextOptions<AppDBContext> options):base(options)
        { 
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p=>p.Price).
                HasColumnType("decimal(18,2)");
        }
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            var conn = "Data Source=DESKTOP-SCEAP9U;Initial Catalog=techfix;Integrated Security=True;Trust Server Certificate=True;";
            optionsBuilder.UseSqlServer(conn);
        }



    }
}
