using Aids.Reflection;
using Data.Shop.DeliveryTypes;
using Domain.Shop.DeliveryTypes;
using Facade.Shop.DeliveryTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.DeliveryTypes;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.DeliveryTypes
{
    [TestClass]
    public class DeliveryTypesPageTests : SealedViewsPageTests<DeliveryTypesPage,
            IDeliveryTypesRepository, DeliveryType, DeliveryTypeView, DeliveryTypeData>
    {

        internal class deliveryTypeRepository : UniqueRepository<DeliveryType, DeliveryTypeData>, IDeliveryTypesRepository
        {
            protected override string GetId(DeliveryTypeData d) => d.Id;
        }

        private deliveryTypeRepository DeliveryType;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            DeliveryType = new deliveryTypeRepository();
            obj = new DeliveryTypesPage(DeliveryType);
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

        protected override DeliveryType CreateObj(DeliveryTypeData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(DeliveryTypeView item)
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