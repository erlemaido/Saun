using Aids.Reflection;
using Data.Shop.Statuses;
using Domain.Shop.Statuses;
using Facade.Shop.Statuses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Statuses
{
    [TestClass]
    public class StatusViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(StatusViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<StatusView>();
            var data = StatusViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<StatusData>();
            var view = StatusViewFactory.Create(new Status(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
