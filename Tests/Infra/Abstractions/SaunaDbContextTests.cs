using System;
using System.Linq;
using System.Linq.Expressions;
using Aids.Reflection;
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
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Abstractions
{
    [TestClass]
    public class SaunaDbContextTests : BaseClassTests<SaunaDbContext, DbContext>
    {

        private DbContextOptions<SaunaDbContext> options;

        private class TestClass : SaunaDbContext
        {
            public TestClass(DbContextOptions<SaunaDbContext> o) : base(o) { }

            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);

                return mb;
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            options = new DbContextOptionsBuilder<SaunaDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new SaunaDbContext(options);
        }

        [TestMethod]
        public void InitializeTablesTest()
        {
            static void TestKey<T>(IMutableEntityType entity, params Expression<Func<T, object>>[] values)
            {
                var key = entity.FindPrimaryKey();

                if (values is null) Assert.IsNull(key);
                else
                    foreach (var v in values)
                    {
                        var name = GetMember.Name(v);
                        Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == name));
                    }
            }

            static void TestEntity<T>(ModelBuilder b, params Expression<Func<T, object>>[] values)
            {
                var name = typeof(T).FullName ?? string.Empty;
                var entity = b.Model.FindEntityType(name);
                Assert.IsNotNull(entity, name);
                TestKey(entity, values);
            }

            var o = new TestClass(options);
            var builder = o.RunOnModelCreating();
            SaunaDbContext.InitializeTables(builder);
            TestEntity<BasketItemData>(builder);
            TestEntity<BrandData>(builder);
            TestEntity<BasketData>(builder);
            TestEntity<CityData>(builder);
            TestEntity<CountryData>(builder);
            TestEntity<DeliveryTypeData>(builder);
            TestEntity<OrderItemData>(builder);
            TestEntity<OrderData>(builder);
            TestEntity<OrderStatusData>(builder);
            TestEntity<PaymentTypeData>(builder);
            TestEntity<PaymentData>(builder);
            TestEntity<PersonData>(builder);
            TestEntity<ProductData>(builder);
            TestEntity<ProductTypeData>(builder);
            TestEntity<ReviewData>(builder);
            TestEntity<RoleData>(builder);
            TestEntity<StatusData>(builder);
            TestEntity<StockData>(builder);
            TestEntity<UnitData>(builder);
            TestEntity<UserRoleData>(builder);
            TestEntity<UserData>(builder);
        }

        [TestMethod]
        public void BasketItemsTest() => IsNullableProperty(obj, nameof(obj.BasketItems), typeof(DbSet<BasketItemData>));

        [TestMethod]
        public void BrandsTest() => IsNullableProperty(obj, nameof(obj.Brands), typeof(DbSet<BrandData>));

        [TestMethod]
        public void BasketsTest() => IsNullableProperty(obj, nameof(obj.Baskets), typeof(DbSet<BasketData>));

        [TestMethod]
        public void CitiesTest() => IsNullableProperty(obj, nameof(obj.Cities), typeof(DbSet<CityData>));

        [TestMethod]
        public void CountriesTest() => IsNullableProperty(obj, nameof(obj.Countries), typeof(DbSet<CountryData>));

        [TestMethod]
        public void DeliveryTypesTest() => IsNullableProperty(obj, nameof(obj.DeliveryTypes), typeof(DbSet<DeliveryTypeData>));

        [TestMethod]
        public void OrderItemsTest() => IsNullableProperty(obj, nameof(obj.OrderItems), typeof(DbSet<OrderItemData>));

        [TestMethod]
        public void OrdersTest() => IsNullableProperty(obj, nameof(obj.Orders), typeof(DbSet<OrderData>));
        [TestMethod]
        public void OrderStatusesTest() => IsNullableProperty(obj, nameof(obj.OrderStatuses), typeof(DbSet<OrderStatusData>));

        [TestMethod]
        public void PaymentTypesTest() => IsNullableProperty(obj, nameof(obj.PaymentTypes), typeof(DbSet<PaymentTypeData>));
        [TestMethod]
        public void PaymentsTest() => IsNullableProperty(obj, nameof(obj.Payments), typeof(DbSet<PaymentData>));

        [TestMethod]
        public void PeopleTest() => IsNullableProperty(obj, nameof(obj.People), typeof(DbSet<PersonData>));

        [TestMethod]
        public void ProductsTest() => IsNullableProperty(obj, nameof(obj.Products), typeof(DbSet<ProductData>));

        [TestMethod]
        public void ProductTypesTest() => IsNullableProperty(obj, nameof(obj.ProductTypes), typeof(DbSet<ProductTypeData>));

        [TestMethod]
        public void ReviewsTest() => IsNullableProperty(obj, nameof(obj.Reviews), typeof(DbSet<ReviewData>));

        [TestMethod]
        public void RolesTest() => IsNullableProperty(obj, nameof(obj.Roles), typeof(DbSet<RoleData>));

        [TestMethod]
        public void StatusesTest() => IsNullableProperty(obj, nameof(obj.Statuses), typeof(DbSet<StatusData>));
        [TestMethod]
        public void StockTest() => IsNullableProperty(obj, nameof(obj.Stock), typeof(DbSet<StockData>));

        [TestMethod]
        public void UnitsTest() => IsNullableProperty(obj, nameof(obj.Units), typeof(DbSet<UnitData>));

        [TestMethod]
        public void UserRolesTest() => IsNullableProperty(obj, nameof(obj.UserRoles), typeof(DbSet<UserRoleData>));

        [TestMethod]
        public void UsersTest() => IsNullableProperty(obj, nameof(obj.Users), typeof(DbSet<UserData>));

    }
}
