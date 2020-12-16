using Data.Shop.PaymentTypes;
using Domain.Abstractions;

namespace Domain.Shop.PaymentTypes
{
    public sealed class PaymentType : UniqueEntity<PaymentTypeData>
    {
        public PaymentType() : this(null)
        {

        }

        public PaymentType(PaymentTypeData data) : base(data)
        {

        }
    }
}
