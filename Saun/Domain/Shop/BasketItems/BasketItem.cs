using Data.Shop.BasketItems;
using Domain.Abstractions;

namespace Domain.Shop.BasketItems
{
    public sealed class BasketItem : UniqueEntity<BasketItemData>
    {
        public BasketItemData Data { get; set; }
        
        public BasketItem() : this(null)
        {

        }

        public BasketItem(BasketItemData data) : base(data)
        {
            Data = data;
        }
    }
}