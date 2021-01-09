using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.Users;
using Data.Shop.Roles;
using Data.Shop.UserRoles;
using Domain.Shop.Roles;
using Domain.Shop.Users;
using Domain.Shop.UserRoles;
using Facade.Shop.UserRoles;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.UserRoles;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.UserRoles
{
    [TestClass]
    public class UserRolesPageTests : SealedViewPageTests<UserRolesPage,
            IUserRolesRepository, UserRole, UserRoleView, UserRoleData>
    {
        internal class UserRolesTestRepository : UniqueRepository<UserRole, UserRoleData>, IUserRolesRepository
        {
            protected override string GetId(UserRoleData d) => d.Id;

        }
        private class UsersTestRepository : UniqueRepository<User, UserData>, IUsersRepository
        {
            protected override string GetId(UserData d) => d.Id;
        }
        private class RolesTestRepository : UniqueRepository<Role, RoleData>, IRolesRepository
        {
            protected override string GetId(RoleData d)
            {
                return d.Id;
            }

        }

        private UserRolesTestRepository _userRolesTest;
        private UsersTestRepository _usersTest;
        private RolesTestRepository _rolesTest;
        private UserRoleData _data;
        private RoleData _roleData;
        private UserData _userData;

        protected override string GetId(UserRoleView item) => item.Id;

        protected override string PageTitle() => PagesNames.UserRoles;

        protected override string PageUrl() => PagesUrls.UserRoles;
        protected override UserRole CreateObj(UserRoleData d) => new UserRole(d);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _userRolesTest = new UserRolesTestRepository();
            _usersTest = new UsersTestRepository();
            _rolesTest = new RolesTestRepository();
            _data = GetRandom.Object<UserRoleData>();
            _roleData = GetRandom.Object<RoleData>();
            _userData = GetRandom.Object<UserData>();
            AddRandomUsers();
            AddRandomUserRoles();
            AddRandomRoles();

            obj = new UserRolesPage(_userRolesTest, _usersTest, _rolesTest);
        }

        private void AddRandomRoles()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _roleData : GetRandom.Object<RoleData>();
                _rolesTest.Add(new Role(d)).GetAwaiter();
            }
        }

        private void AddRandomUserRoles()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<UserRoleData>();
                _userRolesTest.Add(new UserRole(d)).GetAwaiter();
            }
        }

        private void AddRandomUsers()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _userData : GetRandom.Object<UserData>();
                _usersTest.Add(new User(d)).GetAwaiter();
            }
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Kasutaja rollid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/UserRoles", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<UserRoleView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<UserRoleView>();
            var view = obj.ToView(UserRoleViewFactory.Create(d));
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
        public void GetUserNameTest()
        {
            var name = obj.GetUserName(_userData.Id);
            Assert.AreEqual(_userData.PersonId, name);
        }

        [TestMethod]
        public void UsersTest()
        {
            var list = _usersTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Users.Count());
        }

        [TestMethod]
        public void GetRoleNameTest()
        {
            var name = obj.GetRoleName(_roleData.Id);
            Assert.AreEqual(_roleData.Name, name);
        }

        [TestMethod]
        public void RolesTest()
        {
            var list = _rolesTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Roles.Count());
        }

      
    }

}