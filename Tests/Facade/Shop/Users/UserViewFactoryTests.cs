using Aids.Reflection;
using Data.Shop.Users;
using Domain.Shop.Users;
using Facade.Shop.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Users
{
    [TestClass]
    public class UserViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(UserViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<UserView>();
            var data = UserViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<UserData>();
            var view = UserViewFactory.Create(new User(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
