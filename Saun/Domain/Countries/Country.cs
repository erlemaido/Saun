using Data.Countries;
using Domain.Abstractions;

namespace Domain.Countries
{
    public sealed class Country : NamedEntity<CountryData>
    {
        public Country() : this(null)
        {

        }

        public Country(CountryData data) : base(data)
        {

        }
    }
}
