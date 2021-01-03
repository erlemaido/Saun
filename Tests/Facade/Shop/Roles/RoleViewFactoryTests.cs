using Aids.Reflection;
using Data.Shop.Roles;
using Domain.Shop.Roles;
using Facade.Shop.Roles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Roles
{
    [TestClass]
    public class RoleViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(RoleViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<RoleView>();
            var data = RoleViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<RoleData>();
            var view = RoleViewFactory.Create(new Role(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
