using Data.Abstractions;

namespace Data.Shop.Baskets
{
    public sealed class BasketData : NamedEntityData
    {
        public string PersonId { get; set; }
        public double TotalPrice { get; set; }
    }
}