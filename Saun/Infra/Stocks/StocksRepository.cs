using Data.Stocks;
using Domain.Stocks;
using Infra.Abstractions;

namespace Infra.Stocks
{
    public sealed class StocksRepository : UniqueEntityRepository<Stock, StockData>, IStocksRepository
    {
        
    }
}