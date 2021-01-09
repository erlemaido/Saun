using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Infra;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Abstractions
{
    [TestClass]
    public class FilteredRepositoryTests : AbstractClassTests<FilteredRepository<Order, OrderData>,
        SortedRepository<Order, OrderData>>
    {

        private class TestClass : FilteredRepository<Order, OrderData>
        {
            public TestClass(DbContext c, DbSet<OrderData> s) : base(c, s) { }

            protected internal override Order ToDomainObject(OrderData d) => new Order(d);
            protected override OrderData GetDataById(OrderData d) => dbSet.Find(d.Id);


            protected override async Task<OrderData> GetData(string id)
            {
                return await dbSet.FirstOrDefaultAsync(m => m.Id == id);
            }

            protected override string GetId(Order entity) => entity?.Data?.Id;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var c = new SaunaDbContext(options);
            obj = new TestClass(c, c.Orders);
        }

        [TestMethod]
        public void SearchStringTest() => IsNullableProperty(() => obj.SearchString, x => obj.SearchString = x);

        [TestMethod]
        public void FixedFilterTest() => IsNullableProperty(() => obj.FixedFilter, x => obj.FixedFilter = x);

        [TestMethod]
        public void FixedValueTest() => IsNullableProperty(() => obj.FixedValue, x => obj.FixedValue = x);
        [TestMethod]
        public void CurrentFilterTest() => IsNullableProperty(() => obj.CurrentFilter, x => obj.CurrentFilter = x);
        [TestMethod]
        public void CreateSqlQueryTest()
        {
            var sql = obj.CreateSqlQuery();
            Assert.IsNotNull(sql);
        }

        [TestMethod]
        public void AddFixedFilteringTest()
        {
            var sql = obj.CreateSqlQuery();
            var fixedFilter = GetMember.Name<OrderData>(x => x.Street);
            obj.FixedFilter = fixedFilter;
            var fixedValue = GetRandom.String();
            obj.FixedValue = fixedValue;
            var sqlNew = obj.AddFixedFiltering(sql);
            Assert.IsNotNull(sqlNew);
        }

        [TestMethod]
        public void CreateFixedWhereExpressionTest()
        {
            var properties = typeof(OrderData).GetProperties();
            var idx = GetRandom.Int32(0, properties.Length);
            var p = properties[idx];
            obj.FixedFilter = p.Name;
            var fixedValue = GetRandom.String();
            obj.FixedValue = fixedValue;
            var e = obj.CreateFixedWhereExpression();
            Assert.IsNotNull(e);
            var s = e.ToString();

            var expected = p.Name;
            if (p.PropertyType != typeof(string))
                expected += ".ToString()";
            expected += $" == \"{fixedValue}\")";
            Assert.IsTrue(s.Contains(expected));
        }

        [TestMethod]
        public void CreateFixedWhereExpressionOnFixedFilterNullTest()
        {
            Assert.IsNull(obj.CreateFixedWhereExpression());
            obj.FixedValue = GetRandom.String();
            obj.FixedFilter = GetRandom.String();
            Assert.IsNull(obj.CreateFixedWhereExpression());
        }

        [TestMethod]
        public void AddFilteringTest()
        {
            var sql = obj.CreateSqlQuery();
            var searchString = GetRandom.String();
            obj.SearchString = searchString;
            var sqlNew = obj.AddFiltering(sql);
            Assert.IsNotNull(sqlNew);
        }

        [TestMethod]
        public void CreateWhereExpressionTest()
        {
            var searchString = GetRandom.String();
            obj.SearchString = searchString;
            var e = obj.CreateWhereExpression();
            Assert.IsNotNull(e);
            var s = e.ToString();

            foreach (var p in typeof(OrderData).GetProperties())
            {
                var expected = p.Name;
                if (p.PropertyType != typeof(string))
                    expected += ".ToString()";
                expected += $".Contains(\"{searchString}\")";
                Assert.IsTrue(s.Contains(expected));
            }
        }

        [TestMethod]
        public void CreateWhereExpressionWithNullSearchStringTest()
        {
            obj.SearchString = null;
            //var e = obj.CreateWhereExpression();
            //Assert.IsNull(e);
        }
    }
}
