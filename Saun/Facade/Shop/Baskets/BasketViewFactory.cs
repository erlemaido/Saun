using Aids.Methods;
using Data.Shop.Baskets;
using Domain.Shop.Baskets;

namespace Facade.Shop.Baskets
{
    public sealed class BasketViewFactory
    {
        public static Basket Create(BasketView view)
        {
            var basketData = new BasketData();
            Copy.Members(view, basketData);

            return new Basket(basketData);
        }

        public static BasketView Create(Basket order)
        {
            var view = new BasketView();
            Copy.Members(order.Data, view);

            return view;
        }
    }
}
