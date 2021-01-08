using Aids.Methods;
using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Baskets;
using Data.Shop.Orders;
using Data.Shop.OrderStatuses;
using Data.Shop.Statuses;
using Data.Shop.Products;
using Data.Shop.OrderStatuses;
using Domain.Abstractions;
using Domain.Shop.Orders;
using Domain.Shop.OrderStatuses;
using Domain.Shop.Statuses;
using Domain.Shop.Units;
using Domain.Shop.OrderStatuses;
using Facade.Shop.BasketItems;
using Facade.Shop.OrderStatuses;
using Facade.Shop.OrderStatuses;
using Infra.Shop.Statuses;
using Infra.Shop.OrderStatuses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.OrderStatuses;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.OrderStatuses
{
    [TestClass]
    public class OrderStatusesPageTests : SealedViewPageTests<OrderStatusesPage,
            IOrderStatusesRepository, OrderStatus, OrderStatusView, OrderStatusData>
    {
        internal class orderStatusesRepository : UniqueRepository<OrderStatus, OrderStatusData>, IOrderStatusesRepository
        {
            protected override string GetId(OrderStatusData d) => Compose.Id(d.Id, d.StatusId);

        }
        private class peopleRepository : UniqueRepository<Status, StatusData>, IStatusesRepository
        {
            protected override string GetId(StatusData d) => d.Id;
        }

        private class ordersRepository : UniqueRepository<Order, OrderData>, IOrdersRepository
        {
            protected override string GetId(OrderData d) => d.Id;
        }

        private orderStatusesRepository OrderStatuses;
        private peopleRepository Statuses;
        private ordersRepository Orders;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            OrderStatuses = new orderStatusesRepository();
            Statuses = new peopleRepository();
            Orders = new ordersRepository();
            obj = new OrderStatusesPage(OrderStatuses, Orders, Statuses);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Tellimuse staatused", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/OrderStatuses", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<OrderStatusView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<OrderStatusView>();
            var view = obj.ToView(OrderStatusViewFactory.Create(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetStatusNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void StatusesTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetOrderNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void OrdersTest()
        {
            Assert.IsNull(null);
        }

        protected override OrderStatus CreateObj(OrderStatusData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(OrderStatusView item)
        {
            throw new System.NotImplementedException();
        }

        protected override string PageTitle()
        {
            throw new System.NotImplementedException();
        }

        protected override string PageUrl()
        {
            throw new System.NotImplementedException();
        }

    }

}