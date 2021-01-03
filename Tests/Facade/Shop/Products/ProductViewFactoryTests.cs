using Aids.Reflection;
using Data.Shop.Products;
using Domain.Shop.Products;
using Facade.Shop.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Products

{
    [TestClass]
    public class ProductViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(ProductViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ProductView>();
            var data = ProductViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ProductData>();
            var view = ProductViewFactory.Create(new Product(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
