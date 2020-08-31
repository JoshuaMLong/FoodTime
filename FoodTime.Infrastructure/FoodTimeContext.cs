using FoodTime.Infrastructure.Data.ViewModels;
using FoodTime.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FoodTime.Infrastructure
{
    public class FoodTimeContext : DbContext
    {
        private readonly IConfiguration configuration;

        public FoodTimeContext(DbContextOptions<FoodTimeContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Pastry> Pastry { get; set; }
        public DbSet<PastryDough> PastryDough { get; set; }
        public DbSet<PastryFilling> PastryFilling { get; set; }
        public DbSet<PastryType> PastryType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("FoodTime.API"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pastry>()
                .HasKey(e => e.Id);
            builder.Entity<Pastry>()
                .HasIndex(e => new { e.PastryFillingId, e.PastryDoughId });
            builder.Entity<Pastry>()
                .Property(e => e.Id)
                .HasField("_id")
                .ValueGeneratedOnAdd();

            builder.Entity<Pastry>()
                .Property(e => e.Name)
                .HasField("_name");

            builder.Entity<Pastry>()
                .Property(e => e.Description)
                .HasField("_description");

            builder.Entity<PastryFilling>()
                .HasKey(e => e.Id);
            builder.Entity<PastryFilling>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<PastryDough>()
                .HasKey(e => e.Id);
            builder.Entity<PastryDough>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<PastryType>()
                .HasKey(e => new { pfid = e.PastryFillingId, ptid = e.PastryDoughId })
                .IsClustered();
        }
    }
}