using Data.OrderStatuses;
using Domain.Abstractions;

namespace Domain.OrderStatuses
{
    public sealed class OrderStatus : UniqueEntity<OrderStatusData>
    {
        public OrderStatus() : this(null)
        {

        }

        public OrderStatus(OrderStatusData data) : base(data)
        {

        }
    }
}
