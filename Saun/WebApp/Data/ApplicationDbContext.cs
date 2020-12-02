using Data.Brands;
using Data.Products;
using Data.ProductTypes;
using Data.Stocks;
using Data.Units;
using Infra;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        internal void InitializeTables(ModelBuilder builder)
        {
            SaunaDbContext.InitializeTables(builder);
        }
    }
}
