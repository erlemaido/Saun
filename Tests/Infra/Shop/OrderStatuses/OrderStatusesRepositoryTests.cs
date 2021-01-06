using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.OrderStatuses;
using Domain.Shop.OrderStatuses;
using Infra;
using Infra.Abstractions;
using Infra.Shop.OrderStatuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.OrderStatuses
{
    [TestClass]
    public class OrderStatusesRepositoryTests : RepositoryTests<OrderStatusesRepository, OrderStatus, OrderStatusData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).OrderStatuses;
            obj = new OrderStatusesRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<OrderStatus, OrderStatusData>);
        }

        protected override string GetId(OrderStatusData d) => d.Id;

        protected override OrderStatus GetObject(OrderStatusData d) => new OrderStatus(d);

        protected override void SetId(OrderStatusData d, string id) => d.Id = id;
    }
}
