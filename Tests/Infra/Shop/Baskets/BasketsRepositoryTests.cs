using System;
using Data.Shop.Baskets;
using Domain.Shop.Baskets;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Baskets;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Baskets
{
    [TestClass]
    public class BasketsRepositoryTests : RepositoryTests<BasketsRepository, Basket, BasketData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Baskets;
            obj = new BasketsRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Basket, BasketData>);
        }

        protected override string GetId(BasketData d) => d.Id;

        protected override Basket GetObject(BasketData d) => new Basket(d);

        protected override void SetId(BasketData d, string id) => d.Id = id;
    }
}
