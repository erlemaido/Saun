using Data.Shop.DeliveryTypes;
using Domain.Abstractions;

namespace Domain.Shop.DeliveryTypes
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
