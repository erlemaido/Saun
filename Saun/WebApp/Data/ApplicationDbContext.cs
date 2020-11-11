using Data.Brands;
using Data.Products;
using Data.ProductTypes;
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

        public DbSet<BrandData> Brands { get; set; }
        public DbSet<ProductData> Products { get; set; }
        public DbSet<ProductTypeData> ProductTypes { get; set; }
        public DbSet<StockData> Stocks { get; set; }
        public DbSet<UnitData> Units { get; set; }
    }
}
