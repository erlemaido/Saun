using System;
using System.Collections.Generic;
using System.Text;
using Data.OrderItems;
using Domain.Abstractions;

namespace Domain.OrderItems
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
