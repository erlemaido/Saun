using Aids.Reflection;
using Data.Shop.Orders;
using Data.Shop.PaymentTypes;
using Data.Shop.People;
using Domain.Shop.Orders;
using Domain.Shop.PaymentTypes;
using Domain.Shop.People;
using Facade.Shop.PaymentTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.PaymentTypes;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.PaymentTypes
{
    [TestClass]
    public class PaymentTypePageTests : SealedViewPageTests<PaymentTypesPage,
            IPaymentTypesRepository, PaymentType, PaymentTypeView, PaymentTypeData>
    {

        internal class PaymentTypeTestRepository : UniqueRepository<PaymentType, PaymentTypeData>, IPaymentTypesRepository
        {
            protected override string GetId(PaymentTypeData d) => d.Id;
        }

        private PaymentTypeTestRepository _paymentTypeTest;

        protected override string GetId(PaymentTypeView item) => item.Id;

        protected override string PageTitle() => PagesNames.PaymentTypes;

        protected override string PageUrl() => PagesUrls.PaymentTypes;
        protected override PaymentType CreateObj(PaymentTypeData d) => new PaymentType(d);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _paymentTypeTest = new PaymentTypeTestRepository();
            obj = new PaymentTypesPage(_paymentTypeTest);
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
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }



    }

}