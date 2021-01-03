using Aids.Reflection;
using Data.Shop.Brands;
using Domain.Shop.Brands;
using Facade.Shop.Brands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Brands
{
    [TestClass]
    public class BrandViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(BrandViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<BrandView>();
            var data = BrandViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<BrandData>();
            var view = BrandViewFactory.Create(new Brand(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
