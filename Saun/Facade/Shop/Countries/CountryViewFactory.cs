using Aids.Methods;
using Data.Shop.Countries;
using Domain.Shop.Countries;

namespace Facade.Shop.Countries
{
    public sealed class CountryViewFactory
    {
        public static Country Create(CountryView view)
        {
            var countryData = new CountryData();

            Copy.Members(view, countryData);
            return new Country(countryData);
        }

        public static CountryView Create(Country country)
        {
            var view = new CountryView();
            Copy.Members(country.Data, view);
            return view;
        }
    }
}
