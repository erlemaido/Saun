using System.Collections.Generic;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.Brands;
using Data.Shop.DeliveryTypes;
using Domain.Shop.Brands;
using Domain.Shop.DeliveryTypes;
using Facade.Shop.DeliveryTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.DeliveryTypes;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.DeliveryTypes
{
    [TestClass]
    public class DeliveryTypesPageTests : SealedViewsPageTests<DeliveryTypesPage,
            IDeliveryTypesRepository, DeliveryType, DeliveryTypeView, DeliveryTypeData>
    {

        internal class DeliveryTypeTestRepository : UniqueRepository<DeliveryType, DeliveryTypeData>, IDeliveryTypesRepository
        {
            protected override string GetId(DeliveryTypeData d) => d.Id;
            public Task AddAll(List<DeliveryType> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private DeliveryTypeTestRepository _deliveryTypeTest;

        protected override string GetId(DeliveryTypeView item) => item.Id;

        protected override string PageTitle() => PagesNames.DeliveryTypes;

        protected override string PageUrl() => PagesUrls.DeliveryTypes;
        protected override DeliveryType CreateObj(DeliveryTypeData d) => new DeliveryType(d);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _deliveryTypeTest = new DeliveryTypeTestRepository();
            obj = new DeliveryTypesPage(_deliveryTypeTest);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Tarne tüübid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/DeliveryTypes", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<DeliveryTypeView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<DeliveryTypeView>();
            var view = obj.ToView(DeliveryTypeViewFactory.Create(d));
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