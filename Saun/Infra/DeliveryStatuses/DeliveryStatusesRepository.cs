using System;
using System.Collections.Generic;
using System.Text;
using Domain.DeliveryStatuses;
using Infra.Abstractions;

namespace Infra.DeliveryStatuses
{
    public sealed class DeliveryStatusesRepository : UniqueEntityRepository<DeliveryStatus, DeliveryStatusData>, IDeliveryStatusesRepository
    {
        protected internal override DeliveryStatus ToDomainObject(DeliveryStatusData data) => new DeliveryStatus(data);

        public DeliveryStatusesRepository(SaunaDbContext context) : base(context, context.Statuses)
        {
        }
    }
}
