using Data.Shop.Stocks;
using Domain.Abstractions;

namespace Domain.Shop.Stocks
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