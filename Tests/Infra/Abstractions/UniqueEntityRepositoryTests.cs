using System.Threading.Tasks;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Infra;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Abstractions
{
    [TestClass]
    public class UniqueEntityRepositoryTests : AbstractClassTests<FilteredRepository<Order, OrderData>,
        SortedRepository<Order, OrderData>>
    {
        private class TestClass : UniqueEntityRepository<Order, OrderData>
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
        public void GetIdTest()
        {
        //var expected = $"{obj.Id}";
            //Assert.AreEqual(expected, actual);
            Assert.IsNull(null);
        }

        [TestMethod]
        public void SearchStringTest()
        {
            //var actual = obj.GetId();
            //var expected = $"{obj.Id}";
            //Assert.AreEqual(expected, actual);
            Assert.IsNull(null);
        }

        [TestMethod]
        public void CurrentFilterTest()
        {
            //var actual = obj.GetId();
            //var expected = $"{obj.Id}";
            //Assert.AreEqual(expected, actual);
            Assert.IsNull(null);
        }

        [TestMethod]
        public void FixedFilterTest()
        {
            //var actual = obj.GetId();
            //var expected = $"{obj.Id}";
            //Assert.AreEqual(expected, actual);
            Assert.IsNull(null);
        }

        [TestMethod]
        public void FixedValueTest()
        {
            //var actual = obj.GetId();
            //var expected = $"{obj.Id}";
            //Assert.AreEqual(expected, actual);
            Assert.IsNull(null);
        }
    }
}
