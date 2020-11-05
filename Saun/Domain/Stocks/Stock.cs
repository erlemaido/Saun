using Data.Stocks;
using Domain.Abstractions;

namespace Domain.Stocks
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