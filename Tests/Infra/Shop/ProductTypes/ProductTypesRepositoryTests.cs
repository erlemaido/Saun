using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.ProductTypes;
using Domain.Shop.ProductTypes;
using Infra;
using Infra.Abstractions;
using Infra.Shop.ProductTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.ProductTypes
{
    [TestClass]
    public class ProductTypesRepositoryTests : RepositoryTests<ProductTypesRepository, ProductType, ProductTypeData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).ProductTypes;
            obj = new ProductTypesRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<ProductType, ProductTypeData>);
        }

        protected override string GetId(ProductTypeData d) => d.Id;

        protected override ProductType GetObject(ProductTypeData d) => new ProductType(d);

        protected override void SetId(ProductTypeData d, string id) => d.Id = id;
    }
}
