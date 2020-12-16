using Data.Shop.OrderItems;
using Domain.Abstractions;

namespace Domain.Shop.OrderItems
{
    public sealed class OrderItem : UniqueEntity<OrderItemData>
    {
        public OrderItem() : this(null)
        {

        }

        public OrderItem(OrderItemData data) : base(data)
        {

        }
    }
}
