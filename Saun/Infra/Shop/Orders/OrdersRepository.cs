using Data.Shop.Orders;
using Domain.Shop.Orders;
using Infra.Abstractions;

namespace Infra.Shop.Orders
{
    public sealed class OrdersRepository : UniqueEntityRepository<Order, OrderData>, IOrdersRepository
    {
        protected internal override Order ToDomainObject(OrderData data) => new Order(data);

        public OrdersRepository(SaunaDbContext context) : base(context, context.Orders)
        {
        }
    }
}
