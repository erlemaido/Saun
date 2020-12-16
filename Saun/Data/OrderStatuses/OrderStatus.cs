using System;

namespace Data.OrderStatuses
{
    public class OrderStatus
    {
        public string OrderId { get; set; }
        public string StatusId { get; set; }
        public DateTime Time { get; set; }
        public string Comment { get; set; }
    }
}