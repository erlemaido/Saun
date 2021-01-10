using Data.Abstractions;

namespace Data.Shop.BasketItems
{
    public sealed class BasketItemData  : UniqueEntityData
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}