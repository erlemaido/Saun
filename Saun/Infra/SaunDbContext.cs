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

        public DbSet<CatalogItemBrandData> CatalogItemBrands { get; set; }
        public DbSet<CatalogItemData> CatalogItems { get; set; }
        public DbSet<CatalogItemTypeData> CatalogItemTypes { get; set; }
        public DbSet<StockData> Stocks { get; set; }
        public DbSet<UnitData> Units { get; set; }

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