using Aids.Reflection;
using Data.Shop.OrderItems;
using Domain.Shop.OrderItems;
using Facade.Shop.OrderItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.OrderItems
{
    [TestClass]
    public class OrderItemViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(OrderItemViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<OrderItemView>();
            var data = OrderItemViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<OrderItemData>();
            var view = OrderItemViewFactory.Create(new OrderItem(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
