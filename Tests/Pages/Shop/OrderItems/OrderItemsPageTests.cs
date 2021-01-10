using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.OrderItems;
using Data.Shop.Orders;
using Data.Shop.Products;
using Domain.Shop.OrderItems;
using Domain.Shop.Orders;
using Domain.Shop.Products;
using Facade.Shop.OrderItems;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.OrderItems;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.OrderItems
{
    [TestClass]
    public class OrderItemsPageTests : SealedViewPageTests<OrderItemsPage,
            IOrderItemsRepository, OrderItem, OrderItemView, OrderItemData>
    {

        private OrderItemTestRepository _orderItemsTest;
        private ProductTestRepository _productsTest;
        private OrdersTestRepository _ordersTest;
        private OrderItemData _data;
        private ProductData _productData;
        private OrderData _orderData;
        private string _selectedId;
        protected override string GetId(OrderItemView item) => item.Id;

        protected override string PageTitle() => PagesNames.OrderItems;

        protected override string PageUrl() => PagesUrls.OrderItems;
        protected override OrderItem CreateObj(OrderItemData d) => new OrderItem(d);


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            _selectedId = GetRandom.String();
            _orderItemsTest = new OrderItemTestRepository();
            _productsTest = new ProductTestRepository();
            _ordersTest = new OrdersTestRepository();
            _data = GetRandom.Object<OrderItemData>();
            _productData = GetRandom.Object<ProductData>();
            _orderData = GetRandom.Object<OrderData>();
            AddRandomOrderItems();
            AddRandomProducts();
            AddRandomOrders();
            obj = new OrderItemsPage(_orderItemsTest, _ordersTest, _productsTest);

        }

        private void AddRandomOrders()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _orderData : GetRandom.Object<OrderData>();
                _ordersTest.Add(new Order(d)).GetAwaiter();
            }
        }

        private void AddRandomProducts()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _productData : GetRandom.Object<ProductData>();
                _productsTest.Add(new Product(d)).GetAwaiter();
            }
        }

        private void AddRandomOrderItems()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<OrderItemData>();
                _orderItemsTest.Add(new OrderItem(d)).GetAwaiter();
            }
        }

        private class OrderItemTestRepository
            : UniqueRepository<OrderItem, OrderItemData>,
                IOrderItemsRepository
        {
            protected override string GetId(OrderItemData d) => d.Id;

            public Task AddAll(List<OrderItem> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private class ProductTestRepository
            : UniqueRepository<Product, ProductData>,
                IProductsRepository
        {
            protected override string GetId(ProductData d) => d.Id;
            public Task AddAll(List<Product> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private class OrdersTestRepository
            : UniqueRepository<Order, OrderData>,
                IOrdersRepository
        {
            protected override string GetId(OrderData d) => d.Id;
            public Task AddAll(List<Order> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        [TestMethod]
        public override void ToObjectTest()

        {
            var view = GetRandom.Object<OrderItemView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<OrderItemData>();
            var view = obj.ToView(CreateObj(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void ProductsTest()
        {
            var list = _productsTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Products.Count());
        }

        [TestMethod]
        public void OrdersTest()
        {
            var list = _ordersTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Orders.Count());
        }


        [TestMethod]
        public void GetProductNameTest()
        {
            var name = obj.GetProductName(_productData.Id);
            Assert.AreEqual(_productData.Name, name);
        }

        [TestMethod]
        public void GetOrderNameTest()
        {
            var name = obj.GetOrderName(_orderData.Id);
            Assert.AreEqual(_orderData.Name, name);
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Tellimuse read", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/OrderItems", obj.PageUrl.ToString());
        
    }

}
