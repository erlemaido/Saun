using Data.Shop.BasketItems;
using Data.Shop.Baskets;
using Data.Shop.Brands;
using Data.Shop.Cities;
using Data.Shop.Countries;
using Data.Shop.DeliveryTypes;
using Data.Shop.OrderItems;
using Data.Shop.Orders;
using Data.Shop.OrderStatuses;
using Data.Shop.Payments;
using Data.Shop.PaymentTypes;
using Data.Shop.People;
using Data.Shop.Products;
using Data.Shop.ProductTypes;
using Data.Shop.Reviews;
using Data.Shop.Roles;
using Data.Shop.Statuses;
using Data.Shop.Stocks;
using Data.Shop.Units;
using Data.Shop.UserRoles;
using Data.Shop.Users;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class SaunaDbContext : DbContext
    {
        public SaunaDbContext(DbContextOptions<SaunaDbContext> options) : base(options) { }

        public DbSet<BasketItemData> BasketItems { get; set; }
        public DbSet<BasketData> Baskets { get; set; }
        public DbSet<BrandData> Brands { get; set; }
        public DbSet<CityData> Cities { get; set; }
        public DbSet<CountryData> Countries { get; set; }
        public DbSet<DeliveryTypeData> DeliveryTypes { get; set; }
        public DbSet<OrderItemData> OrderItems { get; set; }
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderStatusData> OrderStatuses { get; set; }
        public DbSet<PaymentData> Payments { get; set; }
        public DbSet<PaymentTypeData> PaymentTypes { get; set; }
        public DbSet<PersonData> People { get; set; }
        public DbSet<ProductData> Products { get; set; }
        public DbSet<ProductTypeData> ProductTypes { get; set; }
        public DbSet<ReviewData> Reviews { get; set; }
        public DbSet<RoleData> Roles { get; set; }
        public DbSet<StatusData> Statuses { get; set; }
        public DbSet<StockData> Stock { get; set; }
        public DbSet<UnitData> Units { get; set; }
        public DbSet<UserRoleData> UserRoles { get; set; }
        public DbSet<UserData> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            builder.Entity<BasketItemData>().ToTable(nameof(BasketItems));
            builder.Entity<BasketData>().ToTable(nameof(Baskets));
            builder.Entity<BrandData>().ToTable(nameof(Brands));
            
            builder.Entity<CityData>().ToTable(nameof(Cities));
            builder.Entity<CountryData>().ToTable(nameof(Countries));
            builder.Entity<DeliveryTypeData>().ToTable(nameof(DeliveryTypes));
            builder.Entity<OrderItemData>().ToTable(nameof(OrderItems));
            
            builder.Entity<OrderData>().ToTable(nameof(Orders));
            builder.Entity<OrderStatusData>().ToTable(nameof(OrderStatuses));
            builder.Entity<PaymentData>().ToTable(nameof(Payments));
            builder.Entity<PaymentTypeData>().ToTable(nameof(PaymentTypes));
            
            builder.Entity<PersonData>().ToTable(nameof(People));
            builder.Entity<ProductData>().ToTable(nameof(Products));
            builder.Entity<ProductTypeData>().ToTable(nameof(ProductTypes));
            builder.Entity<ReviewData>().ToTable(nameof(Reviews));
            
            builder.Entity<RoleData>().ToTable(nameof(Roles));
            builder.Entity<StatusData>().ToTable(nameof(Statuses));
            builder.Entity<StockData>().ToTable(nameof(Stock));
            builder.Entity<UnitData>().ToTable(nameof(Units));
            
            builder.Entity<UserRoleData>().ToTable(nameof(UserRoles));
            builder.Entity<UserData>().ToTable(nameof(Users));
        }
    }
}