using Aids.Reflection;
using Data.Shop.Payments;
using Data.Shop.People;
using Domain.Shop.Payments;
using Domain.Shop.People;
using Facade.Shop.People;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.People;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.People
{
    [TestClass]
    public class PeoplePageTests : SealedViewPageTests<PeoplePage,
            IPeopleRepository, Person, PersonView, PersonData>
    {
        internal class PeopleTestRepository : UniqueRepository<Person, PersonData>, IPeopleRepository
        {
            protected override string GetId(PersonData d) => d.Id;

        }

        private PeopleTestRepository _peopleTest;
        protected override string GetId(PersonView item) => item.Id;

        protected override string PageTitle() => PagesNames.People;

        protected override string PageUrl() => PagesUrls.People;
        protected override Person CreateObj(PersonData d) => new Person(d);


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _peopleTest = new PeopleTestRepository();
            obj = new PeoplePage(_peopleTest);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Isikud", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/People", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<PersonView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<PersonView>();
            var view = obj.ToView(PersonViewFactory.Create(d));
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