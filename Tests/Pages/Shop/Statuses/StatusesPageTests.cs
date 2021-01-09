using Aids.Reflection;
using Data.Shop.Roles;
using Data.Shop.Statuses;
using Domain.Shop.Roles;
using Domain.Shop.Statuses;
using Facade.Shop.Statuses;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Statuses;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Statuses
{
    [TestClass]
    public class StatusesPageTests : SealedViewsPageTests<StatusesPage,
            IStatusesRepository, Status, StatusView, StatusData>
    {
        internal class StatusesTestRepository : UniqueRepository<Status, StatusData>, IStatusesRepository
        {
            protected override string GetId(StatusData d) => d.Id;

        }

        private StatusesTestRepository _statusesTest;
        protected override string GetId(StatusView item) => item.Id;

        protected override string PageTitle() => PagesNames.Statuses;

        protected override string PageUrl() => PagesUrls.Statuses;
        protected override Status CreateObj(StatusData d) => new Status(d);


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _statusesTest = new StatusesTestRepository();
            obj = new StatusesPage(_statusesTest);
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
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }
        
       

    }

}