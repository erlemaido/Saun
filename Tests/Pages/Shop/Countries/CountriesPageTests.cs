using Data.Shop.Countries;
using Data.Shop.Countries;
using Domain.Abstractions;
using Domain.Shop.Countries;
using Domain.Shop.Countries;
using Facade.Shop.Countries;
using Infra.Shop.Countries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Countries;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Countries
{
    [TestClass]
    public class CountriesPageTests : SealedViewPageTests<CountriesPage,
        ICountriesRepository, Country, CountryView, CountryData>
    {

        private CountriesRepository Countries;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
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

        protected override Country CreateObj(CountryData d)
        {
            throw new System.NotImplementedException();
        }
    }

}
