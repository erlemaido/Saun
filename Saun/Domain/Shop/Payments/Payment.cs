using Data.Shop.Payments;
using Domain.Abstractions;

namespace Domain.Shop.Payments
{
    public sealed class Payment : UniqueEntity<PaymentData>
    {
        public Payment() : this(null)
        {

        }

        public Payment(PaymentData data) : base(data)
        {

        }
    }
}
