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
    public class BaseRepositoryTests : AbstractClassTests<BaseRepository<Order, OrderData>, object>
    {
        private OrderData _data;

        private class TestClass : BaseRepository<Order, OrderData>
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
            _data = GetRandom.Object<OrderData>();
        }

        [TestMethod]
        public void GetTest()
        {
            var count = GetRandom.UInt8(15, 30);
            var countBefore = obj.Get().GetAwaiter().GetResult().Count;
            for (var i = 0; i < count; i++)
            {
                _data = GetRandom.Object<OrderData>();
                AddTest();
            }
            Assert.AreEqual(count + countBefore, obj.Get().GetAwaiter().GetResult().Count);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            AddTest();
        }

        [TestMethod]
        public void DeleteTest()
        {
            AddTest();
            var expected = obj.Get(_data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(_data, expected.Data);
            obj.Delete(_data.Id).GetAwaiter();
            expected = obj.Get(_data.Id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
        }

        [TestMethod]
        public void AddTest()
        {
            var expected = obj.Get(_data.Id).GetAwaiter().GetResult();
            Assert.IsNull(expected.Data);
            obj.Add(new Order(_data)).GetAwaiter();
            expected = obj.Get(_data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(_data, expected.Data);
        }

        [TestMethod]
        public void UpdateTest()
        {
            AddTest();
            var newData = GetRandom.Object<OrderData>();
            newData.Id = _data.Id;
            obj.Update(new Order(newData)).GetAwaiter();
            var expected = obj.Get(_data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(newData, expected.Data);
        }
    }
}
