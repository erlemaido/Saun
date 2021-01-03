using Aids.Reflection;
using Data.Shop.Countries;
using Domain.Shop.Countries;
using Facade.Shop.Countries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Countries
{
    [TestClass]
    public class CountryViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(CountryViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<CountryView>();
            var data = CountryViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<CountryData>();
            var view = CountryViewFactory.Create(new Country(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
