using System;
using System.Collections.Generic;
using System.Text;
using Data.DeliveryStatus;
using Domain.Abstractions;

namespace Domain.DeliveryStatuses
{
    public sealed class DeliveryStatus : NamedEntity<DeliveryStatusData>
    {
        public DeliveryStatus() : this(null)
        {

        }

        public DeliveryStatus(DeliveryStatusData data) : base(data)
        {

        }
    }
}
