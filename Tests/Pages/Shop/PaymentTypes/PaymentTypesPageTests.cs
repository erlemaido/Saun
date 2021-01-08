using Aids.Reflection;
using Data.Shop.Orders;
using Data.Shop.PaymentTypes;
using Data.Shop.People;
using Domain.Shop.Orders;
using Domain.Shop.PaymentTypes;
using Domain.Shop.People;
using Facade.Shop.PaymentTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.PaymentTypes;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.PaymentTypes
{
    [TestClass]
    public class PaymentTypePageTests : SealedViewPageTests<PaymentTypesPage,
            IPaymentTypesRepository, PaymentType, PaymentTypeView, PaymentTypeData>
    {
        private class peopleRepository : UniqueRepository<Person, PersonData>, IPeopleRepository
        {
            protected override string GetId(PersonData d) => d.Id;
        }

        private class orderRepository : UniqueRepository<Order, OrderData>, IOrdersRepository
        {
            protected override string GetId(OrderData d) => d.Id;
        }

        internal class paymentTypeRepository : UniqueRepository<PaymentType, PaymentTypeData>, IPaymentTypesRepository
        {
            protected override string GetId(PaymentTypeData d) => d.Id;
        }

        private peopleRepository People;
        private orderRepository Order;
        private paymentTypeRepository PaymentType;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            People = new peopleRepository();
            Order = new orderRepository();
            PaymentType = new paymentTypeRepository();
            obj = new PaymentTypesPage(PaymentType);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Maksevahendid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/PaymentTypes", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<PaymentTypeView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<PaymentTypeView>();
            var view = obj.ToView(PaymentTypeViewFactory.Create(d));
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

        protected override PaymentType CreateObj(PaymentTypeData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(PaymentTypeView item)
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