using System;
using System.Collections.Generic;
using System.Text;
using Data.DeliveryType;
using Domain.Abstractions;

namespace Domain.DeliveryTypes
{
    public sealed class DeliveryType : NamedEntity<DeliveryTypeData>
    {
        public DeliveryType() : this(null)
        {

        }

        public DeliveryType(DeliveryTypeData data) : base(data)
        {

        }
    }
}
