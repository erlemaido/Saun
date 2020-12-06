using System;
using System.Collections.Generic;
using System.Text;
using Data.DeliveryType;
using Domain.DeliveryTypes;
using Infra.Abstractions;

namespace Infra.DeliveryTypes
{
   public sealed class DeliveryTypesRepository : UniqueEntityRepository<DeliveryType, DeliveryTypeData>, IDeliveryTypesRepository
   {
       protected internal override DeliveryType ToDomainObject(DeliveryTypeData data) => new DeliveryType(data);

       public DeliveryTypesRepository(SaunaDbContext context) : base(context, context.DeliveryTypes)
       {
       }
   }
    {
    }
}
