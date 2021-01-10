using Data.Abstractions;

namespace Data.Shop.Baskets
{
    public sealed class BasketData : NamedEntityData
    {
        public double TotalPrice { get; set; }
    }
}