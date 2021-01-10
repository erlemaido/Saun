using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids.Methods;
using Aids.Reflection;
using Data.Shop.Baskets;
using Data.Shop.Orders;
using Data.Shop.OrderStatuses;
using Data.Shop.Statuses;
using Domain.Shop.Baskets;
using Domain.Shop.Orders;
using Domain.Shop.OrderStatuses;
using Domain.Shop.Statuses;
using Facade.Shop.OrderItems;
using Facade.Shop.OrderStatuses;
using Facade.Shop.Statuses;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.OrderStatuses;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.OrderStatuses
{
    [TestClass]
    public class OrderStatusesPageTests : SealedViewPageTests<OrderStatusesPage,
            IOrderStatusesRepository, OrderStatus, OrderStatusView, OrderStatusData>
    {
        internal class OrderStatusesTestRepository : UniqueRepository<OrderStatus, OrderStatusData>, IOrderStatusesRepository
        {
            protected override string GetId(OrderStatusData d) => Compose.Id(d.Id, d.StatusId);

            public Task AddAll(List<OrderStatus> obj)
            {
                throw new System.NotImplementedException();
            }
        }
        private class StatusesTestRepository : UniqueRepository<Status, StatusData>, IStatusesRepository
        {
            protected override string GetId(StatusData d) => d.Id;
            public Task AddAll(List<Status> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private class OrdersTestRepository : UniqueRepository<Order, OrderData>, IOrdersRepository
        {
            protected override string GetId(OrderData d) => d.Id;
            public Task AddAll(List<Order> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private OrderStatusesTestRepository _orderStatusesTest;
        private StatusesTestRepository _statusesTest;
        private OrdersTestRepository _ordersTest;

        private OrderStatusData _data;
        private OrderData _orderData;
        private StatusData _statusData;
        protected override string GetId(OrderStatusView item) => item.Id;

        protected override string PageTitle() => PagesNames.OrderStatuses;

        protected override string PageUrl() => PagesUrls.OrderStatuses;
        protected override OrderStatus CreateObj(OrderStatusData d) => new OrderStatus(d);
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _orderStatusesTest = new OrderStatusesTestRepository();
            _statusesTest = new StatusesTestRepository();
            _ordersTest = new OrdersTestRepository();
            _data = GetRandom.Object<OrderStatusData>();
            _orderData = GetRandom.Object<OrderData>();
            _statusData = GetRandom.Object<StatusData>();
            AddRandomOrderStatuses();
            AddRandomOrders();
            AddRandomStatuses();
            obj = new OrderStatusesPage(_orderStatusesTest, _ordersTest, _statusesTest);
        }

        private bool IsOrder() => obj.FixedFilter == GetMember.Name<OrderStatusView>(x => x.OrderId);

        private bool IsStatus() => obj.FixedFilter == GetMember.Name<OrderStatusView>(x => x.StatusId);

        private void AddRandomStatuses()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _statusData : GetRandom.Object<StatusData>();
                _statusesTest.Add(new Status(d)).GetAwaiter();
            }
        }

        private void AddRandomOrders()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _orderData: GetRandom.Object<OrderData>();
                _ordersTest.Add(new Order(d)).GetAwaiter();
            }
        }

        private void AddRandomOrderStatuses()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<OrderStatusData>();
                _orderStatusesTest.Add(new OrderStatus(d)).GetAwaiter();
            }
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
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod]
        public void GetStatusNameTest()
        {
            var name = obj.GetStatusName(_statusData.Id);
            Assert.AreEqual(_statusData.Name, name);
        }
        [TestMethod]
        public void GetOrderNameTest()
        {
            var name = obj.GetOrderName(_orderData.Id);
            Assert.AreEqual(_orderData.Name, name);
        }
        [TestMethod]
        public void StatusesTest()
        {
            var list = _statusesTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Statuses.Count());
        }

        [TestMethod]
        public void OrdersTest()
        {
            var list = _ordersTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Orders.Count());
        }
        [TestMethod]
        public void GetPageOrderSubtitleTest()
        {
            var list = _ordersTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<OrderStatusView>(x => x.OrderId);
            if (!IsOrder()) return;
            foreach (var order in list.Where(order => order.Id == _orderData.Id))
            {
                obj.FixedValue = order.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }

        }
        [TestMethod]
        public void GetPageStatusSubtitleTest()
        {
            var list = _statusesTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<OrderStatusView>(x => x.StatusId);
            if (!IsStatus()) return;
            foreach (var status in list.Where(status => status.Id == _orderData.Id))
            {
                obj.FixedValue = status.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }

        }



    }

}