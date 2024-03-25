using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySOASolution.Domain;

namespace MySOASolution.Data
{
    public class SamuraiContext : IdentityDbContext<AppIdentityUser>
    {
        public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
        {

        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        //fluent mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Samurai>().HasMany(s => s.Battles).WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>(bs => bs.HasOne<Battle>().WithMany(),
                bs => bs.HasOne<Samurai>().WithMany()).Property(bs => bs.DateJoined).HasDefaultValueSql("getdate()");
            //custom IdentityUser
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=ACTUAL;Initial Catalog=SamuraiDb;Integrated Security=True;TrustServerCertificate=True;");
            //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
            //.EnableSensitiveDataLogging();
        }*/
    }
}
