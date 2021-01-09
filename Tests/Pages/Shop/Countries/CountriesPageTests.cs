using Aids.Reflection;
using Data.Shop.Brands;
using Data.Shop.Countries;
using Domain.Shop.Brands;
using Domain.Shop.Countries;
using Facade.Shop.Countries;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Countries;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Countries
{
    [TestClass]
    public class CountriesPageTests : SealedViewsPageTests<CountriesPage,
            ICountriesRepository, Country, CountryView, CountryData>
    {
        internal class CountriesTestRepository : UniqueRepository<Country, CountryData>, ICountriesRepository
        {
            protected override string GetId(CountryData d) => d.Id;

        }

        private CountriesTestRepository _countriesTest;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _countriesTest = new CountriesTestRepository();
            obj = new CountriesPage(_countriesTest);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Riigid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Countries", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<CountryView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<CountryView>();
            var view = obj.ToView(CountryViewFactory.Create(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }


        protected override string GetId(CountryView item) => item.Id;

        protected override string PageTitle() => PagesNames.Countries;

        protected override string PageUrl() => PagesUrls.Countries;
        protected override Country CreateObj(CountryData d) => new Country(d);


    }

}