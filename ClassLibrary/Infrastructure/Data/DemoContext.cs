using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data
{
    public class DemoContext : DbContext
    {
        //public DemoContext()
        //{
        //}
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = localhost; database = DemoCSharp; Trusted_Connection = true");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Product> Products { get; set; }
    }
}
