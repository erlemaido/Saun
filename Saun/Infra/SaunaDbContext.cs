using Data.Brands;
using Data.Cities;
using Data.DeliveryTypes;
using Data.OrderItems;
using Data.Orders;
using Data.Products;
using Data.ProductTypes;
using Data.Units;
using Microsoft.EntityFrameworkCore;
using Data.Users;
using Data.UserRoles;
using Data.Roles;
using Data.Reviews;
using Data.Stock;

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
        public DbSet<DeliveryCountryData> Countries { get; set; }
        public DbSet<DeliveryTypeData> DeliveryTypes { get; set; }
        public DbSet<DeliveryCityData> Cities { get; set; }
        public DbSet<DeliveryStatusData> Statuses { get; set; }
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderItemData> OrderItems { get; set; }
        public DbSet<ReviewData> Reviews { get; set; }
        public DbSet<RoleData> Roles { get; set; }
        public DbSet<UserRoleData> UserRoles { get; set; }
        public DbSet<UserData> Users { get; set; }


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
            builder.Entity<DeliveryTypeData>().ToTable(nameof(DeliveryTypes));
            builder.Entity<DeliveryCountryData>().ToTable(nameof(Countries));
            builder.Entity<DeliveryCityData>().ToTable(nameof(Cities));
            builder.Entity<DeliveryStatusData>().ToTable(nameof(Statuses));
            builder.Entity<OrderData>().ToTable(nameof(Orders));
            builder.Entity<OrderItemData>().ToTable(nameof(OrderItems));
            builder.Entity<ReviewData>().ToTable(nameof(Reviews));
            builder.Entity<RoleData>().ToTable(nameof(Roles));
            builder.Entity<UserRoleData>().ToTable(nameof(UserRoles));
            builder.Entity<UserData>().ToTable(nameof(Users));

        }
    }
}