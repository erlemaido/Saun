using Aids.Reflection;
using Data.Shop.Baskets;
using Domain.Shop.Baskets;
using Facade.Shop.Baskets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Baskets
{
    [TestClass]
    public class BasketViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(BasketViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<BasketView>();
            var data = BasketViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<BasketData>();
            var view = BasketViewFactory.Create(new Basket(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
