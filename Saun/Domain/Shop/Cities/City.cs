using Data.Shop.Cities;
using Domain.Abstractions;

namespace Domain.Shop.Cities
{
    public sealed class City : NamedEntity<CityData>
    {
        public City() : this(null)
        {

        }

        public City(CityData data) : base(data)
        {

        }
    }
}
