using Data.DeliveryTypes;
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
