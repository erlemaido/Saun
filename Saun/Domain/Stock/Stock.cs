using Data.Stock;
using Domain.Abstractions;

namespace Domain.Stock
{
    public sealed class Stock : UniqueEntity<StockData>
    {
        public Stock() : this(null!)
        {
            
        }

        public Stock(StockData data) : base(data)
        {
            
        }
        
    }
}