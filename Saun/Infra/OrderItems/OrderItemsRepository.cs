using System;
using System.Collections.Generic;
using System.Text;
using Data.OrderItems;
using Domain.OrderItems;
using Infra.Abstractions;

namespace Infra.OrderItems
{
    public sealed class OrderItemsRepository : UniqueEntityRepository<OrderItem, OrderItemData>, IOrderItemsRepository
    {
        protected internal override OrderItem ToDomainObject(OrderItemData data) => new OrderItem(data);

        public OrderItemsRepository(SaunaDbContext context) : base(context, context.OrderItems)
        {
        }
    }
}
