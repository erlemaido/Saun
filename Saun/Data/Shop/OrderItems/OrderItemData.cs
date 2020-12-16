using Data.Abstractions;

namespace Data.Shop.OrderItems
{
    public class OrderItemData : UniqueEntityData
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
