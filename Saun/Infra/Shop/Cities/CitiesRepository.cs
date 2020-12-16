using Data.Shop.Cities;
using Domain.Shop.Cities;
using Infra.Abstractions;

namespace Infra.Shop.Cities
{
    public sealed class CitiesRepository : UniqueEntityRepository<City, CityData>, ICitiesRepository
    {
        protected internal override City ToDomainObject(CityData data) => new City(data);

        public CitiesRepository(SaunaDbContext context) : base(context, context.Cities)
        {
        }
    }
    
}
