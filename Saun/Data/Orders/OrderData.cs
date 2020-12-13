using System;
using System.Collections.Generic;
using System.Text;
using Data.Abstractions;

namespace Data.Orders
{
    public class OrderData : UniqueEntityData
    {
        public string PersonId { get; set; }
        public string UserId { get; set; }
        public string DeliveryTypeId { get; set; }
        public string DeliveryCityId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public double DeliveryCost { get; set; }

    }
}
