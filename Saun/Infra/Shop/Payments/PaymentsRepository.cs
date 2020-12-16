using Data.Shop.Payments;
using Domain.Shop.Payments;
using Infra.Abstractions;

namespace Infra.Shop.Payments
{
    public sealed class PaymentsRepository : UniqueEntityRepository<Payment, PaymentData>, IPaymentsRepository
    {
        protected internal override Payment ToDomainObject(PaymentData data) => new Payment(data);

        public PaymentsRepository(SaunaDbContext context) : base(context, context.Payments)
        {
        }
    }
}