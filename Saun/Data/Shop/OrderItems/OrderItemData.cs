using Data.Abstractions;

namespace Data.Shop.OrderItems
{
    public sealed class OrderItemData : UniqueEntityData
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
