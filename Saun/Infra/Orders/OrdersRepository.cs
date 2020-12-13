using System;
using System.Collections.Generic;
using System.Text;
using Data.Orders;
using Domain.Orders;
using Infra.Abstractions;

namespace Infra.Orders
{
    public sealed class OrdersRepository : UniqueEntityRepository<Order, OrderData>, IOrdersRepository
    {
        protected internal override Order ToDomainObject(OrderData data) => new Order(data);

        public OrdersRepository(SaunaDbContext context) : base(context, context.Orders)
        {
        }
    }
}
