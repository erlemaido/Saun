using System;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Orders
{
    [TestClass]
    public class OrdersRepositoryTests : RepositoryTests<OrdersRepository, Order, OrderData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Orders;
            obj = new OrdersRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Order, OrderData>);
        }

        protected override string GetId(OrderData d) => d.Id;

        protected override Order GetObject(OrderData d) => new Order(d);

        protected override void SetId(OrderData d, string id) => d.Id = id;
    }
}
