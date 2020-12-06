using Data.DeliveryCity;
using Domain.Abstractions;

namespace Domain.DeliveryCities
{
    public sealed class DeliveryCity : NamedEntity<DeliveryCityData>
    {
        public DeliveryCity() : this(null)
        {

        }

        public DeliveryCity(DeliveryCityData data) : base(data)
        {

        }
    }
}
