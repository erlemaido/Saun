using Aids.Reflection;
using Data.Shop.OrderStatuses;
using Domain.Shop.OrderStatuses;
using Facade.Shop.OrderStatuses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.OrderStatuses
{
    [TestClass]
    public class OrderStatusViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(OrderStatusViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<OrderStatusView>();
            var data = OrderStatusViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<OrderStatusData>();
            var view = OrderStatusViewFactory.Create(new OrderStatus(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
