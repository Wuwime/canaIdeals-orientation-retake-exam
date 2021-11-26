using Microsoft.EntityFrameworkCore;
using OrientationRetake.Models.Entities;

namespace OrientationRetake.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Mountain> Mountains { get; set; }
        public DbSet<Climber> Climbers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mountain>()
                .HasMany<Climber>(m => m.ClimbedClimbers)
                .WithOne( c => c.Mountain)
                .HasForeignKey(c => c.MountainId)
                .IsRequired(false);
        }
    }
}