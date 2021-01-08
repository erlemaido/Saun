using Aids.Methods;
using Aids.Reflection;
using Data.Shop.People;
using Data.Shop.Users;
using Domain.Shop.People;
using Domain.Shop.Users;
using Facade.Shop.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Users;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Users
{
    [TestClass]
    public class UsersPageTests : SealedViewPageTests<UsersPage,
            IUsersRepository, User, UserView, UserData>
    {
        internal class UsersRepository : UniqueRepository<User, UserData>, IUsersRepository
        {
            protected override string GetId(UserData d) => Compose.Id(d.Id, d.PersonId);

        }
        private class PeopleRepository : UniqueRepository<Person, PersonData>, IPeopleRepository
        {
            protected override string GetId(PersonData d) => d.Id;
        }

        private UsersRepository _users;
        private PeopleRepository _people;
        

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _users = new UsersRepository();
            _people = new PeopleRepository();
            obj = new UsersPage(_users, _people);
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

        protected override User CreateObj(UserData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(UserView item)
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