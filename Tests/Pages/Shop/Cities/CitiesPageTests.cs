using System.Linq;
using Aids.Reflection;
using Data.Shop.Baskets;
using Data.Shop.Cities;
using Data.Shop.Countries;
using Domain.Shop.Baskets;
using Domain.Shop.Cities;
using Domain.Shop.Countries;
using Facade.Shop.Cities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Cities;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Cities
{
    [TestClass]
    public class CitiesPageTests : SealedViewPageTests<CitiesPage,
        ICitiesRepository, City, CityView, CityData>
    {
        internal class CitiesTestRepository : UniqueRepository<City, CityData>, ICitiesRepository
        {
            protected override string GetId(CityData d) => d.Id;


        }

        private class CountriesTestRepository : UniqueRepository<Country, CountryData>, ICountriesRepository
        {
            protected override string GetId(CountryData d) => d.Id;

        }

        private CitiesTestRepository _cities;
        private CountriesTestRepository _countriesTest;
        private CountryData _countryData;
        protected override string GetId(CityView item) => item.Id;

        protected override string PageTitle() => PagesNames.Cities;

        protected override string PageUrl() => PagesUrls.Cities;
        protected override City CreateObj(CityData d) => new City(d);

        private bool IsCountry() => obj.FixedFilter == GetMember.Name<CityView>(x => x.CountryId);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _cities = new CitiesTestRepository();
            _countriesTest = new CountriesTestRepository();
            _countryData = GetRandom.Object<CountryData>();
            AddRandomCountries();
            obj = new CitiesPage(_cities, _countriesTest);

        }

        private void AddRandomCountries()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _countryData : GetRandom.Object<CountryData>();
                _countriesTest.Add(new Country(d)).GetAwaiter();
            }
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
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod]
        public void GetCountryNameTest()
        {
            var name = obj.GetCountryName(_countryData.Id);
            Assert.AreEqual(_countryData.Name, name);
        }

        [TestMethod]
        public void CountriesTest()
        {
            var list = _countriesTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Countries.Count());
        }

        [TestMethod]
        public void GetPageSubtitleTest()
        {
            var list = _countriesTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<CityView>(x => x.CountryId);
            if (!IsCountry()) return;
            foreach (var country in list.Where(country => country.Id == _countryData.Id))
            {
                obj.FixedValue = country.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }

        }

    }
}