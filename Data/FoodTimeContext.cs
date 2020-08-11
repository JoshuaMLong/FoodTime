using FoodTime.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FoodTime.Data
{
    public class FoodTimeContext : DbContext
    {
        private readonly IConfiguration configuration;

        public FoodTimeContext(DbContextOptions<FoodTimeContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Pastry> Pastry { get; set; }
        public DbSet<PastryType> PastryType { get; set; }
        public DbSet<PastryFilling> PastryFilling { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("FoodTime"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pastry>()
                .HasKey(e => e.Id);
            builder.Entity<Pastry>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<PastryFilling>()
                .HasKey(e => e.Id);
            builder.Entity<PastryFilling>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<PastryType>()
                .HasKey(e => e.Id);
            builder.Entity<PastryType>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}