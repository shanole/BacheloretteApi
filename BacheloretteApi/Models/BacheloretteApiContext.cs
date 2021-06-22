using Microsoft.EntityFrameworkCore;

namespace BacheloretteApi.Models
{
    public class BacheloretteApiContext : DbContext
    {
        public BacheloretteApiContext(DbContextOptions<BacheloretteApiContext> options)
            : base(options)
        {
        }

        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Bachelorette> Bachelorettes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Bachelorette>()
            .HasData(new Bachelorette { BacheloretteId = 1, Name = "Katie Thurston", Age = 30, Job = "Marketing manager", Hometown = "Renton, WA", Season = 17 });
          builder.Entity<Contestant>()
            .HasData(
              new Contestant{ ContestantId = 1, Name = "Greg", Age = 27, Job = "Marketing Sales Representative", Hometown = "Edison, NJ",  IsEliminated = false, Season = 17, BacheloretteId = 1 },
              new Contestant{ ContestantId = 2, Name = "Aaron", Age = 26, Job = "Insurance Agent", Hometown = "San Diego, CA",  IsEliminated = false, Season = 17, BacheloretteId = 1}
            );
        }
    }
}