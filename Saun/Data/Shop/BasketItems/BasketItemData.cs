using Data.Abstractions;

namespace Data.Shop.BasketItems
{
    public class BasketItemData  : UniqueEntityData
    {
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}