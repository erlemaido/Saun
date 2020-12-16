using Data.Shop.DeliveryTypes;
using Domain.Shop.DeliveryTypes;
using Infra.Abstractions;

namespace Infra.Shop.DeliveryTypes
{
   public sealed class DeliveryTypesRepository : UniqueEntityRepository<DeliveryType, DeliveryTypeData>, IDeliveryTypesRepository
   {
       protected internal override DeliveryType ToDomainObject(DeliveryTypeData data) => new DeliveryType(data);

       public DeliveryTypesRepository(SaunaDbContext context) : base(context, context.DeliveryTypes)
       {
       }
   }
    
}
