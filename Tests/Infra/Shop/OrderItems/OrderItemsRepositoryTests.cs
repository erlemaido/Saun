using System;
using Data.Shop.OrderItems;
using Domain.Shop.OrderItems;
using Infra;
using Infra.Abstractions;
using Infra.Shop.OrderItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.OrderItems
{
    [TestClass]
    public class OrderItemsRepositoryTests : RepositoryTests<OrderItemsRepository, OrderItem, OrderItemData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).OrderItems;
            obj = new OrderItemsRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<OrderItem, OrderItemData>);
        }

        protected override string GetId(OrderItemData d) => d.Id;

        protected override OrderItem GetObject(OrderItemData d) => new OrderItem(d);

        protected override void SetId(OrderItemData d, string id) => d.Id = id;
    }
}
