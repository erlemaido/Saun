using Data.Shop.OrderStatuses;
using Domain.Shop.OrderStatuses;
using Infra.Abstractions;

namespace Infra.Shop.OrderStatuses
{
    public sealed class OrderStatusesRepository : UniqueEntityRepository<OrderStatus, OrderStatusData>, IOrderStatusesRepository
    {
        protected internal override OrderStatus ToDomainObject(OrderStatusData data) => new OrderStatus(data);

        public OrderStatusesRepository(SaunaDbContext context) : base(context, context.OrderStatuses)
        {
        }
    }
}