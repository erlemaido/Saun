using Aids.Reflection;
using Data.Shop.ProductTypes;
using Domain.Shop.ProductTypes;
using Facade.Shop.ProductTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.ProductTypes
{
    [TestClass]
    public class ProductTypeViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(ProductTypeViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ProductTypeView>();
            var data = ProductTypeViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ProductTypeData>();
            var view = ProductTypeViewFactory.Create(new ProductType(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
