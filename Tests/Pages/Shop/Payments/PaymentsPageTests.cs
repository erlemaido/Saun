using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids.Methods;
using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Orders;
using Data.Shop.People;
using Data.Shop.Payments;
using Data.Shop.PaymentTypes;
using Domain.Shop.BasketItems;
using Domain.Shop.Orders;
using Domain.Shop.People;
using Domain.Shop.Payments;
using Domain.Shop.PaymentTypes;
using Facade.Shop.Baskets;
using Facade.Shop.OrderItems;
using Facade.Shop.Payments;
using Facade.Shop.PaymentTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Payments;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Payments
{
    [TestClass]
    public class PaymentsPageTests : SealedViewPageTests<PaymentsPage,
            IPaymentsRepository, Payment, PaymentView, PaymentData>
    {
        internal class PaymentsTestRepository : UniqueRepository<Payment, PaymentData>, IPaymentsRepository
        {
            protected override string GetId(PaymentData d) => Compose.Id(d.Id, d.PersonId);

            public Task AddAll(List<Payment> obj)
            {
                throw new System.NotImplementedException();
            }
        }
        private class PeopleTestRepository : UniqueRepository<Person, PersonData>, IPeopleRepository
        {
            protected override string GetId(PersonData d) => d.Id;
            public Task AddAll(List<Person> obj)
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

        private class PaymentTypesTestRepository : UniqueRepository<PaymentType, PaymentTypeData>, IPaymentTypesRepository
        {
            protected override string GetId(PaymentTypeData d) => d.Id;
            public Task AddAll(List<PaymentType> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private PaymentsTestRepository _paymentsTest;
        private PeopleTestRepository _peopleTest;
        private OrdersTestRepository _ordersTest;
        private PaymentTypesTestRepository _paymentTypesTest;
        private PaymentData _data;
        private PersonData _personData;
        private PaymentTypeData _paymentTypeData;
        private OrderData _orderData;

        protected override string GetId(PaymentView item) => item.Id;

        protected override string PageTitle() => PagesNames.Payments;

        protected override string PageUrl() => PagesUrls.Payments;
        protected override Payment CreateObj(PaymentData d) => new Payment(d);
        private bool IsOrder() => obj.FixedFilter == GetMember.Name<PaymentView>(x => x.OrderId);

        private bool IsPerson() => obj.FixedFilter == GetMember.Name<PaymentView>(x => x.PersonId);
        private bool IsPaymentType() => obj.FixedFilter == GetMember.Name<PaymentView>(x => x.PaymentTypeId);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _paymentsTest = new PaymentsTestRepository();
            _peopleTest = new PeopleTestRepository();
            _ordersTest = new OrdersTestRepository();
            _paymentTypesTest = new PaymentTypesTestRepository();
            _data = GetRandom.Object<PaymentData>();
            _personData = GetRandom.Object<PersonData>();
            _orderData = GetRandom.Object<OrderData>();
            _paymentTypeData = GetRandom.Object<PaymentTypeData>();
            AddRandomPayments();
            AddRandomPeople();
            AddRandomOrders();
            AddRandomPaymentTypes();
            obj = new PaymentsPage(_paymentsTest, _ordersTest, _paymentTypesTest, _peopleTest);
        }
        private void AddRandomPaymentTypes()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _paymentTypeData : GetRandom.Object<PaymentTypeData>();
                _paymentTypesTest.Add(new PaymentType(d)).GetAwaiter();
            }
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
        private void AddRandomPeople()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _personData : GetRandom.Object<PersonData>();
                _peopleTest.Add(new Person(d)).GetAwaiter();
            }
        }
        private void AddRandomPayments()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<PaymentData>();
                _paymentsTest.Add(new Payment(d)).GetAwaiter();
            }
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Maksed", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Payments", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<PaymentView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<PaymentView>();
            var view = obj.ToView(PaymentViewFactory.Create(d));
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
        public void GetPersonNameTest()
        {
            var name = obj.GetPersonName(_personData.Id);
            Assert.AreEqual(_personData.FirstName + " " + _personData.LastName, name);
        }

        [TestMethod]
        public void PeopleTest()
        {
            var list = _peopleTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.People.Count());
        }

        [TestMethod]
        public void GetOrderNameTest()
        {
            var name = obj.GetOrderName(_orderData.Id);
            Assert.AreEqual(_orderData.Name, name);
        }

        [TestMethod]
        public void OrdersTest()
        {
            var list = _ordersTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Orders.Count());
        }

        [TestMethod]
        public void GetPaymentTypeNameTest()
        {
            var name = obj.GetPaymentTypeName(_paymentTypeData.Id);
            Assert.AreEqual(_paymentTypeData.Name, name);
        }

        [TestMethod]
        public void PaymentTypesTest()
        {
            var list = _paymentTypesTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.PaymentTypes.Count());
        }

        [TestMethod]
        public void GetPageOrderSubtitleTest()
        {
            var list = _ordersTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<PaymentView>(x => x.OrderId);
            if (!IsOrder()) return;
            foreach (var order in list.Where(order => order.Id == _orderData.Id))
            {
                obj.FixedValue = order.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }

        }
        [TestMethod]
        public void GetPagePersonSubtitleTest()
        {
            var list = _peopleTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<PaymentView>(x => x.PersonId);
            if (!IsPerson()) return;
            foreach (var person in list.Where(person => person.Id == _personData.Id))
            {
                obj.FixedValue = person.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }

        }

        [TestMethod]
        public void GetPagePaymentTypeSubtitleTest()
        {
            var list = _paymentTypesTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<PaymentView>(x => x.PaymentTypeId);
            if (!IsPaymentType()) return;
            foreach (var paymentType in list.Where(paymentType => paymentType.Id == _paymentTypeData.Id))
            {
                obj.FixedValue = _paymentTypeData.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);

            }


        }

    }

}