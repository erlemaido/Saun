using Aids.Methods;
using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Baskets;
using Data.Shop.Orders;
using Data.Shop.People;
using Data.Shop.Products;
using Data.Shop.Payments;
using Data.Shop.PaymentTypes;
using Domain.Abstractions;
using Domain.Shop.Orders;
using Domain.Shop.People;
using Domain.Shop.Units;
using Domain.Shop.Payments;
using Domain.Shop.PaymentTypes;
using Facade.Shop.BasketItems;
using Facade.Shop.Payments;
using Infra.Shop.People;
using Infra.Shop.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Payments;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Payments
{
    [TestClass]
    public class PaymentsPageTests : SealedViewPageTests<PaymentsPage,
            IPaymentsRepository, Payment, PaymentView, PaymentData>
    {
        internal class paymentsRepository : UniqueRepository<Payment, PaymentData>, IPaymentsRepository
        {
            protected override string GetId(PaymentData d) => Compose.Id(d.Id, d.PersonId);

        }
        private class peopleRepository : UniqueRepository<Person, PersonData>, IPeopleRepository
        {
            protected override string GetId(PersonData d) => d.Id;
        }

        private class orderRepository : UniqueRepository<Order, OrderData>, IOrdersRepository
        {
            protected override string GetId(OrderData d) => d.Id;
        }

        private class paymentTypeRepository : UniqueRepository<PaymentType, PaymentTypeData>, IPaymentTypesRepository
        {
            protected override string GetId(PaymentTypeData d) => d.Id;
        }

        private paymentsRepository Payments;
        private peopleRepository People;
        private orderRepository Order;
        private paymentTypeRepository PaymentType;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Payments = new paymentsRepository();
            People = new peopleRepository();
            Order = new orderRepository();
            PaymentType = new paymentTypeRepository();
            obj = new PaymentsPage(Payments, Order, PaymentType, People);
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
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetPersonNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void PeopleTest()
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

        [TestMethod]
        public void GetPaymentTypeNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void PaymentTypesTest()
        {
            Assert.IsNull(null);
        }

        protected override Payment CreateObj(PaymentData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(PaymentView item)
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