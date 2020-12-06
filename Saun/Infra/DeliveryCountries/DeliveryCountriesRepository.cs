using System;
using System.Collections.Generic;
using System.Text;
using Data.Brands;
using Data.DeliveryCountry;
using Domain.Brands;
using Domain.DeliveryCountries;
using Infra.Abstractions;

namespace Infra.DeliveryCountries
{
    public sealed class DeliveryCountriesRepository : UniqueEntityRepository<DeliveryCountry, DeliveryCountryData>, IDeliveryCountriesRepository
    {
        protected internal override DeliveryCountry ToDomainObject(DeliveryCountryData data) => new DeliveryCountry(data);

        public DeliveryCountriesRepository(SaunaDbContext context) : base(context, context.Countries)
        {
        }
    }
    
}
