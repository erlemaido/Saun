using System.Linq;
using Aids.Methods;
using Aids.Reflection;
using Data.Shop.Baskets;
using Data.Shop.People;
using Data.Shop.Users;
using Domain.Shop.Baskets;
using Domain.Shop.People;
using Domain.Shop.Users;
using Facade.Shop.Baskets;
using Facade.Shop.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Users;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Users
{
    [TestClass]
    public class UsersPageTests : SealedViewPageTests<UsersPage,
            IUsersRepository, User, UserView, UserData>
    {
        internal class UsersTestRepository : UniqueRepository<User, UserData>, IUsersRepository
        {
            protected override string GetId(UserData d) => Compose.Id(d.Id, d.PersonId);

        }
        private class PeopleTestRepository : UniqueRepository<Person, PersonData>, IPeopleRepository
        {
            protected override string GetId(PersonData d) => d.Id;
        }

        private UsersTestRepository _usersTest;
        private PeopleTestRepository _peopleTest;
        private UserData _data;
        private PersonData _peopleData;
        protected override string GetId(UserView item) => item.Id;

        protected override string PageTitle() => PagesNames.Baskets;

        protected override string PageUrl() => PagesUrls.BasketItems;
        protected override User CreateObj(UserData d) => new User(d);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _usersTest = new UsersTestRepository();
            _peopleTest = new PeopleTestRepository();
            _data = GetRandom.Object<UserData>();
            _peopleData = GetRandom.Object<PersonData>();
            AddRandomPeople();
            AddRandomUsers();
            obj = new UsersPage(_usersTest, _peopleTest);
        }

        private void AddRandomUsers()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<UserData>();
                _usersTest.Add(new User(d)).GetAwaiter();
            }
        }

        private void AddRandomPeople()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _peopleData : GetRandom.Object<PersonData>();
                _peopleTest.Add(new Person(d)).GetAwaiter();
            }
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Kasutajad", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Users", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<UserView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<UserView>();
            var view = obj.ToView(UserViewFactory.Create(d));
            TestArePropertyValuesEqual(view, d);
        }


        [TestMethod]
        public void OnGetCreateTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }
        [TestMethod]
        public void PeopleTest()
        {
            var list = _peopleTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.People.Count());
        }

        [TestMethod]
        public void GetPersonNameTest()
        {
            var name = obj.GetPersonName(_peopleData.Id);
            Assert.AreEqual(_peopleData.FirstName + " " + _peopleData.LastName, name);
        }

       

    }

}