using Data.Shop.OrderItems;
using Domain.Shop.OrderItems;
using Infra.Abstractions;

namespace Infra.Shop.OrderItems
{
    public sealed class OrderItemsRepository : UniqueEntityRepository<OrderItem, OrderItemData>, IOrderItemsRepository
    {
        protected internal override OrderItem ToDomainObject(OrderItemData data) => new OrderItem(data);

        public OrderItemsRepository(SaunaDbContext context) : base(context, context.OrderItems)
        {
        }
    }
}
