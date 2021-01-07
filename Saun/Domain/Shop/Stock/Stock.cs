using Data.Shop.Stock;
using Domain.Abstractions;

namespace Domain.Shop.Stock
{
    public sealed class Stock : UniqueEntity<StockData>
    {
        public Stock() : this(null)
        {
            
        }

        public Stock(StockData data) : base(data)
        {
            
        }
    }
}