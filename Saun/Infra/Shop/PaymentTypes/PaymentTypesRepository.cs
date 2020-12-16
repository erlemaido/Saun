using Data.Shop.PaymentTypes;
using Domain.Shop.PaymentTypes;
using Infra.Abstractions;

namespace Infra.Shop.PaymentTypes
{
    public sealed class PaymentTypesRepository : UniqueEntityRepository<PaymentType, PaymentTypeData>, IPaymentTypesRepository
    {
        protected internal override PaymentType ToDomainObject(PaymentTypeData data) => new PaymentType(data);

        public PaymentTypesRepository(SaunaDbContext context) : base(context, context.PaymentTypes)
        {
        }
    }
}