using FoodTime.API.Data.Models;
using FoodTime.API.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FoodTime.API.Data
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
        public DbSet<PastryStock> PastryStock { get; set; }

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
                .HasIndex(e => new { e.PastryFillingId, e.PastryTypeId });
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

            builder.Entity<PastryType>()
                .HasKey(e => e.Id);
            builder.Entity<PastryType>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<PastryStock>()
                .HasKey(e => new { pfid = e.PastryFillingId, ptid = e.PastryTypeId })
                .IsClustered();
        }
    }
}