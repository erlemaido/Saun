using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions;

namespace Domain.DeliveryStatuses
{
    public interface IDeliveryStatusesRepository : IRepository<DeliveryStatus>
    {
    }
}
