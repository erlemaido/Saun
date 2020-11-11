using Data.Brands;
using Data.Products;
using Data.ProductTypes;
using Data.Stocks;
using Data.Units;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class SaunaDbContext : DbContext
    {
        public SaunaDbContext(DbContextOptions<SaunaDbContext> options) : base(options) { }

        public DbSet<BrandData> Brands { get; set; }
        public DbSet<ProductData> Products { get; set; }
        public DbSet<ProductTypeData> ProductTypes { get; set; }
        public DbSet<StockData> Stocks { get; set; }
        public DbSet<UnitData> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            builder.Entity<BrandData>().ToTable(nameof(Brands));
            builder.Entity<ProductTypeData>().ToTable(nameof(ProductTypes));
            builder.Entity<UnitData>().ToTable(nameof(Units));
            builder.Entity<ProductData>().ToTable(nameof(Products));
            builder.Entity<StockData>().ToTable(nameof(Stocks));
        }
    }
}