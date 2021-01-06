using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.Products;
using Domain.Shop.Products;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Products
{
    [TestClass]
    public class ProductsRepositoryTests : RepositoryTests<ProductsRepository, Product, ProductData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Products;
            obj = new ProductsRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Product, ProductData>);
        }

        protected override string GetId(ProductData d) => d.Id;

        protected override Product GetObject(ProductData d) => new Product(d);

        protected override void SetId(ProductData d, string id) => d.Id = id;
    }
}
