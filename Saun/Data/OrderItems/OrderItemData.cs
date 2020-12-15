using System;
using System.Collections.Generic;
using System.Text;
using Data.Abstractions;

namespace Data.OrderItems
{
    public class OrderItemData : UniqueEntityData
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
