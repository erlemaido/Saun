using Saun.Data.Stock;
using Saun.Domain.Abstractions;

namespace Saun.Domain.StockDomain
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