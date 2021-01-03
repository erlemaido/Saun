using Aids.Methods;
using Data.Shop.Cities;
using Domain.Shop.Cities;

namespace Facade.Shop.Cities
{
    public sealed class CityViewFactory
    {
        public static City Create(CityView view)
        {
            var cityData = new CityData();

            Copy.Members(view, cityData);
            return new City(cityData);
        }

        public static CityView Create(City city)
        {
            var view = new CityView();
            Copy.Members(city.Data, view);
            return view;
        }
    }
}
