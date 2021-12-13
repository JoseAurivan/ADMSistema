using AdmSemas.Models;
using Microsoft.EntityFrameworkCore;

namespace AdmSemas.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .ToTable("user")
                .HasIndex(x => x.Username)
                .IsUnique();

            modelBuilder
                .Entity<User>()
                .Property(x => x.Username)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();
            
            modelBuilder
                .Entity<User>()
                .Property(x => x.Email)
                .IsRequired();;
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer("Server=localhost;Database=teste05;" +
                                        "Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
