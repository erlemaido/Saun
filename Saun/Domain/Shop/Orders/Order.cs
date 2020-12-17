using Data.Shop.Orders;
using Domain.Abstractions;

namespace Domain.Shop.Orders
{
    public sealed class Order : NamedEntity<OrderData>
    {
        public Order() : this(null)
        {

        }

        public Order(OrderData data) : base(data)
        {

        }
    }
}
