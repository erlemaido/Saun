using Data.Shop.Stock;
using Domain.Shop.Stock;
using Infra.Abstractions;

namespace Infra.Shop.Stock
{
    public sealed class StockRepository : UniqueEntityRepository<Domain.Shop.Stock.Stock, StockData>, IStockRepository
    {
        protected internal override Domain.Shop.Stock.Stock ToDomainObject(StockData data) => new Domain.Shop.Stock.Stock(data);

        public StockRepository(SaunaDbContext context) : base(context, context.Stock)
        {
        }
    }
}