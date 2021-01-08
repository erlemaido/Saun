using Aids.Reflection;
using Data.Shop.People;
using Domain.Shop.People;
using Facade.Shop.People;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.People;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.People
{
    [TestClass]
    public class PeoplePageTests : SealedViewPageTests<PeoplePage,
            IPeopleRepository, Person, PersonView, PersonData>
    {
        internal class peopleRepository : UniqueRepository<Person, PersonData>, IPeopleRepository
        {
            protected override string GetId(PersonData d) => d.Id;

        }

        private peopleRepository People;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            People = new peopleRepository();
            obj = new PeoplePage(People);
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

        protected override Person CreateObj(PersonData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(PersonView item)
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