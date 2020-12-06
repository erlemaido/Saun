using System;
using System.Collections.Generic;
using System.Text;
using Data.DeliveryCity;
using Domain.DeliveryCities;
using Infra.Abstractions;

namespace Infra.DeliveryCities
{
    public sealed class DeliveryCitiesRepository : UniqueEntityRepository<DeliveryCity, DeliveryCityData>, IDeliveryCitiesRepository
    {
        protected internal override DeliveryCity ToDomainObject(DeliveryCityData data) => new DeliveryCity(data);

        public DeliveryCitiesRepository(SaunaDbContext context) : base(context, context.Cities)
        {
        }
    }
    
}
