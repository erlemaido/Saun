using Aids.Methods;
using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Baskets;
using Data.Shop.People;
using Data.Shop.Products;
using Data.Shop.Statuses;
using Domain.Abstractions;
using Domain.Shop.People;
using Domain.Shop.Units;
using Domain.Shop.Statuses;
using Facade.Shop.BasketItems;
using Facade.Shop.Statuses;
using Infra.Shop.People;
using Infra.Shop.Statuses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Statuses;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Statuses
{
    [TestClass]
    public class StatusesPageTests : SealedViewsPageTests<StatusesPage,
            IStatusesRepository, Status, StatusView, StatusData>
    {
        internal class statusesRepository : UniqueRepository<Status, StatusData>, IStatusesRepository
        {
            protected override string GetId(StatusData d) => d.Id;

        }

        private statusesRepository Statuses;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Statuses = new statusesRepository();
            obj = new StatusesPage(Statuses);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Tellimuse staatused", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Statuses", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<StatusView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<StatusView>();
            var view = obj.ToView(StatusViewFactory.Create(d));
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

        protected override Status CreateObj(StatusData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(StatusView item)
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