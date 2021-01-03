using Aids.Reflection;
using Data.Shop.UserRoles;
using Domain.Shop.UserRoles;
using Facade.Shop.UserRoles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.UserRoles
{
    [TestClass]
    public class UserRoleViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(UserRoleViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<UserRoleView>();
            var data = UserRoleViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<UserRoleData>();
            var view = UserRoleViewFactory.Create(new UserRole(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
