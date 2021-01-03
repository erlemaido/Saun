using Aids.Reflection;
using Data.Shop.Units;
using Domain.Shop.Units;
using Facade.Shop.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Units
{
    [TestClass]
    public class UnitViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(UnitViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<UnitView>();
            var data = UnitViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<UnitData>();
            var view = UnitViewFactory.Create(new Unit(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
