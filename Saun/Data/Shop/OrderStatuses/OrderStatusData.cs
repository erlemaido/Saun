using System;
using Data.Abstractions;

namespace Data.Shop.OrderStatuses
{
    public sealed class OrderStatusData : UniqueEntityData
    {
        public string OrderId { get; set; }
        public string StatusId { get; set; }
        public DateTime Time { get; set; }
        public string Comment { get; set; }
    }
}