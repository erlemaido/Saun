using Data.CatalogItemBrands;
using Data.CatalogItems;
using Data.CatalogItemTypes;
using Data.Stocks;
using Data.Units;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class SaunDbContext : DbContext
    {
        public SaunDbContext(DbContextOptions<SaunDbContext> options) : base(options) { }

        public DbSet<CatalogItemBrandData> CatalogItemBrands { get; set; } = null!;
        public DbSet<CatalogItemData> CatalogItems { get; set; } = null!;
        public DbSet<CatalogItemTypeData> CatalogItemTypes { get; set; } = null!;
        public DbSet<StockData> Stocks { get; set; } = null!;
        public DbSet<UnitData> Units { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            builder.Entity<CatalogItemBrandData>().ToTable(nameof(CatalogItemBrands));
            builder.Entity<CatalogItemTypeData>().ToTable(nameof(CatalogItemTypes));
            builder.Entity<UnitData>().ToTable(nameof(Units));
            builder.Entity<CatalogItemData>().ToTable(nameof(CatalogItems));
            builder.Entity<StockData>().ToTable(nameof(Stocks));
        }
    }
}