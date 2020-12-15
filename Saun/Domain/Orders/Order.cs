using Data.Orders;
using Domain.Abstractions;

namespace Domain.Orders
{
    public sealed class Order : UniqueEntity<OrderData>
    {
        public Order() : this(null)
        {

        }

        public Order(OrderData data) : base(data)
        {

        }
    }
}
