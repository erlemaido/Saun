using System.Collections.Generic;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.Users;
using Data.Shop.Roles;
using Data.Shop.UserRoles;
using Domain.Shop.Roles;
using Domain.Shop.Users;
using Domain.Shop.UserRoles;
using Facade.Shop.UserRoles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.UserRoles;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.UserRoles
{
    [TestClass]
    public class UserRolesPageTests : SealedViewPageTests<UserRolesPage,
            IUserRolesRepository, UserRole, UserRoleView, UserRoleData>
    {
        internal class userRolesRepository : UniqueRepository<UserRole, UserRoleData>, IUserRolesRepository
        {
            protected override string GetId(UserRoleData d) => d.Id;

        }
        private class usersRepository : UniqueRepository<User, UserData>, IUsersRepository
        {
            protected override string GetId(UserData d) => d.Id;
        }
        private class rolesRepository : UniqueRepository<Role, RoleData>, IRolesRepository
        {
            protected override string GetId(RoleData d)
            {
                return d.Id;
            }

            public Task<List<UserRole>> Get()
            {
                throw new System.NotImplementedException();
            }

            public Task<UserRole> Get(string id)
            {
                throw new System.NotImplementedException();
            }

            public Task Add(UserRole obj)
            {
                throw new System.NotImplementedException();
            }

            public Task Update(UserRole obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private userRolesRepository UserRoles;
        private usersRepository Users;
        private rolesRepository Roles;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            UserRoles = new userRolesRepository();
            Users = new usersRepository();
            Roles = new rolesRepository();
            obj = new UserRolesPage(UserRoles, Users, Roles);
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
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetUserNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void UsersTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetRoleNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void RolesTest()
        {
            Assert.IsNull(null);
        }

        protected override UserRole CreateObj(UserRoleData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(UserRoleView item)
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