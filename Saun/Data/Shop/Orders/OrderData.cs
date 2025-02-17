﻿using System;
using System.Collections.Generic;
using Data.Abstractions;
using Data.Shop.OrderItems;
using Data.Shop.Products;

namespace Data.Shop.Orders
{
    public sealed class OrderData : NamedEntityData
    {
        public string PersonId { get; set; }
        public string UserId { get; set; }
        public string DeliveryTypeId { get; set; }
        public string CountryId { get; set; }
        public string CityId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public double DeliveryCost { get; set; }
        public string Comment { get; set; }
        public List<OrderItemData> OrderItems { get; set; }
    }
}
