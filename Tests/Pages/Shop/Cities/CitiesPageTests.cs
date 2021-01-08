using Aids.Reflection;
using Data.Shop.Cities;
using Data.Shop.Countries;
using Domain.Shop.Cities;
using Domain.Shop.Countries;
using Facade.Shop.Cities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Cities;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Cities
{
    [TestClass]
    public class CitiesPageTests : SealedViewPageTests<CitiesPage,
            ICitiesRepository, City, CityView, CityData>
    {
        internal class citiesRepository : UniqueRepository<City, CityData>, ICitiesRepository
        {
            protected override string GetId(CityData d) => d.Id;


        }

        private class countriesRepository : UniqueRepository<Country, CountryData>, ICountriesRepository
        {
            protected override string GetId(CountryData d) => d.Id;

        }

        private citiesRepository Cities;
        private countriesRepository Countries;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Cities = new citiesRepository();
            Countries = new countriesRepository();
            obj = new CitiesPage(Cities, Countries);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Linnad", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Cities", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<CityView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<CityView>();
            var view = obj.ToView(CityViewFactory.Create(d));
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
        public void GetCountryNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void CountriesTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void PeopleTest()
        {
            Assert.IsNull(null);
        }

        protected override City CreateObj(CityData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(CityView item)
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