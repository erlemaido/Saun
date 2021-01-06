using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.BasketItems;
using Domain.Shop.BasketItems;
using Infra;
using Infra.Abstractions;
using Infra.Shop.BasketItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.BasketItems
{
    [TestClass]
    public class BasketItemsRepositoryTests : RepositoryTests<BasketItemsRepository, BasketItem, BasketItemData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).BasketItems;
            obj = new BasketItemsRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<BasketItem, BasketItemData>);
        }

        protected override string GetId(BasketItemData d) => d.Id;

        protected override BasketItem GetObject(BasketItemData d) => new BasketItem(d);

        protected override void SetId(BasketItemData d, string id) => d.Id = id;
    }
}
