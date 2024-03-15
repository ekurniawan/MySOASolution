using Microsoft.EntityFrameworkCore;
using MySOASolution.Domain;

namespace MySOASolution.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ACTUAL;Initial Catalog=SamuraiDb;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
