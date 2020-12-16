using Data.Shop.Countries;
using Domain.Shop.Countries;
using Infra.Abstractions;

namespace Infra.Shop.Countries
{
    public sealed class CountriesRepository : UniqueEntityRepository<Country, CountryData>, ICountriesRepository
    {
        protected internal override Country ToDomainObject(CountryData data) => new Country(data);

        public CountriesRepository(SaunaDbContext context) : base(context, context.Countries)
        {
        }
    }
    
}
