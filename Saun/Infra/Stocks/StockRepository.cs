using Data.Stock;
using Domain.Stock;
using Infra.Abstractions;

namespace Infra.Stocks
{
    public sealed class StockRepository : UniqueEntityRepository<Stock, StockData>, IStockRepository
    {
        protected internal override Stock ToDomainObject(StockData data) => new Stock(data);

        public StockRepository(SaunaDbContext context) : base(context, context.Stocks)
        {
        }
    }
}