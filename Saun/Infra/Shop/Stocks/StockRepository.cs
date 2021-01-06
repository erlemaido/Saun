using Data.Shop.Stocks;
using Domain.Shop.Stocks;
using Infra.Abstractions;

namespace Infra.Shop.Stocks
{
    public sealed class StockRepository : UniqueEntityRepository<Stock, StockData>, IStockRepository
    {
        protected internal override Stock ToDomainObject(StockData data) => new Stock(data);

        public StockRepository(SaunaDbContext context) : base(context, context.Stock)
        {
        }
    }
}