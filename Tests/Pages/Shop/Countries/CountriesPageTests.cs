using Aids.Reflection;
using Data.Shop.Countries;
using Domain.Shop.Countries;
using Facade.Shop.Countries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Countries;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Countries
{
    [TestClass]
    public class CountriesPageTests : SealedViewsPageTests<CountriesPage,
            ICountriesRepository, Country, CountryView, CountryData>
    {
        internal class countriesRepository : UniqueRepository<Country, CountryData>, ICountriesRepository
        {
            protected override string GetId(CountryData d) => d.Id;

        }

        private countriesRepository Countries;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Countries = new countriesRepository();
            obj = new CountriesPage(Countries);
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
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetPersonNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void PeopleTest()
        {
            Assert.IsNull(null);
        }

        protected override Country CreateObj(CountryData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(CountryView item)
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