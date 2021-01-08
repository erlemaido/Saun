using System;
using Data.Shop.Brands;
using Domain.Shop.Brands;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Brands;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Brands
{
    [TestClass]
    public class BrandsRepositoryTests : RepositoryTests<BrandsRepository, Brand, BrandData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Brands;
            obj = new BrandsRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Brand, BrandData>);
        }

        protected override string GetId(BrandData d) => d.Id;

        protected override Brand GetObject(BrandData d) => new Brand(d);

        protected override void SetId(BrandData d, string id) => d.Id = id;
    }
}
