using Data.Brands;
using Data.Products;
using Data.ProductTypes;
using Data.Stocks;
using Data.Units;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class SaunDbContext : DbContext
    {
        public SaunDbContext(DbContextOptions<SaunDbContext> options) : base(options) { }

        public DbSet<BrandData> CatalogItemBrands { get; set; }
        public DbSet<ProductData> CatalogItems { get; set; }
        public DbSet<ProductTypeData> CatalogItemTypes { get; set; }
        public DbSet<StockData> Stocks { get; set; }
        public DbSet<UnitData> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            builder.Entity<BrandData>().ToTable(nameof(CatalogItemBrands));
            builder.Entity<ProductTypeData>().ToTable(nameof(CatalogItemTypes));
            builder.Entity<UnitData>().ToTable(nameof(Units));
            builder.Entity<ProductData>().ToTable(nameof(CatalogItems));
            builder.Entity<StockData>().ToTable(nameof(Stocks));
        }
    }
}