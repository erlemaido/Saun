using Data.Abstractions;

namespace Data.Shop.Baskets
{
    public class BasketData : NamedEntityData
    {
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
    }
}