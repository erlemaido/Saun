using Aids.Methods;
using Data.Shop.BasketItems;
using Domain.Shop.BasketItems;

namespace Facade.Shop.BasketItems
{
    public class BasketItemViewFactory
    {
        public static BasketItem Create(BasketItemView view)
        {
            var basketItemData = new BasketItemData();
            Copy.Members(view, basketItemData);

            return new BasketItem(basketItemData);
        }

        public static BasketItemView Create(BasketItem basketItem)
        {
            var view = new BasketItemView();
            Copy.Members(basketItem.Data, view);

            return view;
        }
    }
}
