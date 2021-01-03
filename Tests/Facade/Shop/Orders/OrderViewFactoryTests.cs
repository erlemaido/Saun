using Aids.Reflection;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Facade.Shop.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Orders
{
    [TestClass]
    public class OrderViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(OrderViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<OrderView>();
            var data = OrderViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<OrderData>();
            var view = OrderViewFactory.Create(new Order(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
