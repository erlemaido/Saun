using System.Linq;
using Aids.Reflection;
using Data.Shop.Baskets;
using Data.Shop.People;
using Domain.Shop.Baskets;
using Domain.Shop.People;
using Facade.Shop.Baskets;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Baskets;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Baskets
{
    [TestClass]
    public class BasketsPageTests : SealedViewPageTests<BasketsPage, IBasketsRepository, Basket, BasketView, BasketData>
    {
        private TestRepository repository;
        private peopleRepository People;
        private BasketData data;
        private PersonData peopleData;
        private string SelectedId;
        protected override string GetId(BasketView item) => item.Id;

        protected override string PageTitle() => PagesNames.Baskets;

        protected override string PageUrl() => PagesUrls.BasketItems;
        protected override Basket CreateObj(BasketData d) => new Basket(d);
        private bool IsPerson() => obj.FixedFilter == GetMember.Name<BasketView>(x => x.PersonId);


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            SelectedId = GetRandom.String();
            repository = new TestRepository();
            People = new peopleRepository();
            data = GetRandom.Object<BasketData>();
            peopleData = GetRandom.Object<PersonData>();
            AddRandomPeople();
            AddRandomBaskets();
            obj = new BasketsPage(repository, People);
        }

        private void AddRandomBaskets()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? data : GetRandom.Object<BasketData>();
                repository.Add(new Basket(d)).GetAwaiter();
            }
        }

        private void AddRandomPeople()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? peopleData : GetRandom.Object<PersonData>();
                People.Add(new Person(d)).GetAwaiter();
            }
        }

        private class TestRepository
            : UniqueRepository<Basket, BasketData>,
                IBasketsRepository
        {
            protected override string GetId(BasketData d) => d.Id;

        }

        private class peopleRepository
            : UniqueRepository<Person, PersonData>,
                IPeopleRepository
        {
            protected override string GetId(PersonData d) => d.Id;
        }

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<BasketView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<BasketData>();
            var view = obj.ToView(CreateObj(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void PeopleTest()
        {
            var list = People.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.People.Count());
        }

        [TestMethod]
        public void GetPersonNameTest()
        {
            var name = obj.GetPersonName(peopleData.Id);
            Assert.AreEqual(peopleData.FirstName + " " + peopleData.LastName, name);
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Ostukorvid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Baskets", obj.PageUrl.ToString());

        [TestMethod]
        public void GetPageSubtitleTest()
        {
            var list = People.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<BasketView>(x => x.PersonId);
            if (!IsPerson()) return;
            foreach (var person in list.Where(person => person.Id == peopleData.Id))
            {
                obj.FixedValue = person.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }



        }
    }
}