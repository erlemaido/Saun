using System;
using Data.Shop.Stocks;
using Domain.Shop.Stocks;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Stocks
{
    [TestClass]
    public class StockRepositoryTests : RepositoryTests<StockRepository,Stock, StockData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Stock;
            obj = new StockRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Stock, StockData>);
        }

        protected override string GetId(StockData d) => d.Id;

        protected override Stock GetObject(StockData d) => new Stock(d);

        protected override void SetId(StockData d, string id) => d.Id = id;
    }
}
