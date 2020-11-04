using Data.CatalogItemBrands;
using Data.CatalogItems;
using Data.CatalogItemTypes;
using Data.Stocks;
using Data.Units;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CatalogItemBrandData> CatalogItemBrands { get; set; } = null!;
        public DbSet<CatalogItemData> CatalogItems { get; set; } = null!;
        public DbSet<CatalogItemTypeData> CatalogItemTypes { get; set; } = null!;
        public DbSet<StockData> Stocks { get; set; } = null!;
        public DbSet<UnitData> Units { get; set; } = null!;
    }
}
