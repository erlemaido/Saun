using Aids.Reflection;
using Data.Shop.Cities;
using Domain.Shop.Cities;
using Facade.Shop.Cities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Cities
{
    [TestClass]
    public class CityViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(CityViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<CityView>();
            var data = CityViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<CityData>();
            var view = CityViewFactory.Create(new City(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
