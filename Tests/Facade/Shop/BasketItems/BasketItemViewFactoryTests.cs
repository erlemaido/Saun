using Aids.Reflection;
using Data.Shop.BasketItems;
using Domain.Shop.BasketItems;
using Facade.Shop.BasketItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.BasketItems
{
    [TestClass]
    public class BasketItemViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(BasketItemViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<BasketItemView>();
            var data = BasketItemViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<BasketItemData>();
            var view = BasketItemViewFactory.Create(new BasketItem(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
