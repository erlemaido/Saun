﻿using System;
using Data.Shop.Stock;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Stock
{
    [TestClass]
    public class StockRepositoryTests : RepositoryTests<StockRepository,global::Domain.Shop.Stock.Stock, StockData>
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
            return typeof(UniqueEntityRepository<global::Domain.Shop.Stock.Stock, StockData>);
        }

        protected override string GetId(StockData d) => d.Id;

        protected override global::Domain.Shop.Stock.Stock GetObject(StockData d) => new global::Domain.Shop.Stock.Stock(d);

        protected override void SetId(StockData d, string id) => d.Id = id;
    }
}
