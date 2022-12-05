using Microsoft.EntityFrameworkCore;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Core.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Animal>().ToTable("Animals");
            builder.Entity<Animal>().HasKey(p => p.Id);
            builder.Entity<Animal>().Property(p => p.Id).IsRequired();
            builder.Entity<Animal>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Animal>().Property(p => p.Species).IsRequired().HasMaxLength(100);
            builder.Entity<Animal>().Property(p => p.Color).HasMaxLength(100);
            builder.Entity<Animal>().Property(p => p.MicrochipNumber);
            builder.Entity<Animal>().Property(p => p.DateOfBirth);
            builder.Entity<Animal>().Property(p => p.DateInShelter);
            builder.Entity<Animal>().Property(p => p.DateLost);
            builder.Entity<Animal>().Property(p => p.DateFound);
            builder.Entity<Animal>().Property(p => p.AgeYears);
            builder.Entity<Animal>().Property(p => p.AgeMonths);
            builder.Entity<Animal>().Property(p => p.AgeMonths);
            builder.Entity<Animal>().Property(p => p.AgeWeeks);

            builder.Entity<Animal>().HasData
            (
                new Animal
                {
                    Id = Guid.NewGuid(),
                    Name = "Billy",
                    Color = "Brown",
                    Species = "Dog",
                    DateOfBirth = Convert.ToDateTime("2020-08-01"),
                    DateInShelter = Convert.ToDateTime("2022-01-01"),
                    AgeYears = 6,
                    AgeMonths = 4,
                    AgeWeeks = 1
                }
            );
        }
    }
}
