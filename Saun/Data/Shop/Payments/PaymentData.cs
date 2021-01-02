using System;
using Data.Abstractions;

namespace Data.Shop.Payments
{
    public sealed class PaymentData : UniqueEntityData
    {
        public string OrderId { get; set; }
        public string PersonId { get; set; }
        public string PaymentTypeId { get; set; }
        public DateTime Time { get; set; }
    }
}