using Data.Stocks;
using Domain.Stocks;
using Infra.Abstractions;

namespace Infra.Stocks
{
    public sealed class StocksRepository : UniqueEntityRepository<Stock, StockData>, IStocksRepository
    {
        protected internal override Stock ToDomainObject(StockData data) => new Stock(data);

        public StocksRepository(SaunaDbContext context) : base(context, context.Stocks)
        {
        }
    }
}