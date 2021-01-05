using System;
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
    public class PaginatedRepositoryTests : AbstractClassTests<PaginatedRepository<Order, OrderData>, FilteredRepository<Order, OrderData>>
    {
        private class TestClass : PaginatedRepository<Order, OrderData>
        {
            public TestClass(DbContext c, DbSet<OrderData> s) : base(c, s) { }

            protected internal override Order ToDomainObject(OrderData d) => new Order(d);
            protected override OrderData GetDataById(OrderData d) => dbSet.Find(d.Id);


            protected override async Task<OrderData> GetData(string id) => await dbSet.FirstOrDefaultAsync(m => m.Id == id);

            protected override string GetId(Order entity) => entity?.Data?.Id;
        }

        private byte _count;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var c = new SaunaDbContext(options);
            obj = new TestClass(c, c.Orders);
            _count = GetRandom.UInt8(20, 40);
            foreach (var p in c.Orders)
                c.Entry(p).State = EntityState.Deleted;
            AddItems();
        }

        [TestMethod]
        public void PageIndexTest()
        {
            IsProperty(() => obj.PageIndex, x => obj.PageIndex = x);
        }

        [TestMethod]
        public void TotalPagesTest()
        {
            var expected = (int)Math.Ceiling(_count / (double)obj.PageSize);
            var totalPagesCount = obj.TotalPages;
            Assert.AreEqual(expected, totalPagesCount);
        }

        [TestMethod]
        public void HasNextPageTest()
        {
            void TestNextPage(int pageIndex, bool expected)
            {
                obj.PageIndex = pageIndex;
                var actual = obj.HasNextPage;
                Assert.AreEqual(expected, actual);
            }

            TestNextPage(0, true);
            TestNextPage(1, true);
            TestNextPage(GetRandom.Int32(2, obj.TotalPages - 1), true);
            TestNextPage(obj.TotalPages, false);
        }

        [TestMethod]
        public void HasPreviousPageTest()
        {
            void TestPreviousPage(int pageIndex, bool expected)
            {
                obj.PageIndex = pageIndex;
                var actual = obj.HasPreviousPage;
                Assert.AreEqual(expected, actual);
            }
            TestPreviousPage(0, false);
            TestPreviousPage(1, false);
            TestPreviousPage(2, true);
            TestPreviousPage(GetRandom.Int32(2, obj.TotalPages), true);
            TestPreviousPage(obj.TotalPages, true);
        }

        [TestMethod]
        public void PageSizeTest()
        {
            Assert.AreEqual(5, obj.PageSize);
            IsProperty(() => obj.PageSize, x => obj.PageSize = x);
        }

        [TestMethod]
        public void GetTotalPagesTest()
        {
            var expected = (int)Math.Ceiling(_count / (double)obj.PageSize);
            var totalPagesCount = obj.GetTotalPages(obj.PageSize);
            Assert.AreEqual(expected, totalPagesCount);
        }

        [TestMethod]
        public void CountTotalPagesTest()
        {
            var expected = (int)Math.Ceiling(_count / (double)obj.PageSize);
            var totalPagesCount = obj.CountTotalPages(_count, obj.PageSize);
            Assert.AreEqual(expected, totalPagesCount);
        }

        [TestMethod]
        public void GetItemsCountTest()
        {
            var itemsCount = obj.GetItemsCount();
            Assert.AreEqual(_count, itemsCount);
        }

        private void AddItems()
        {
            for (var i = 0; i < _count; i++)
                obj.Add(new Order(GetRandom.Object<OrderData>())).GetAwaiter();
        }

        [TestMethod]
        public void CreateSqlQueryTest()
        {
            var o = obj.CreateSqlQuery();
            Assert.IsNotNull(o);
        }

        [TestMethod]
        public void AddSkipAndTakeTest()
        {
            var sql = obj.CreateSqlQuery();

            var o = obj.AddSkipAndTake(sql);
            Assert.IsNotNull(o);
        }
    }
}
