using Data.Shop.BasketItems;
using Data.Shop.Baskets;
using Domain.Abstractions;

namespace Domain.Shop.Baskets
{
    public sealed class Basket : NamedEntity<BasketData>
    {

        public Basket() : this(null)
        {

        }

        public Basket(BasketData data) : base(data)
        {
        }
    }
}