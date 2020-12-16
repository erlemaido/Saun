using System;
using System.Collections.Generic;
using System.Text;
using Data.Cities;
using Domain.Cities;
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
