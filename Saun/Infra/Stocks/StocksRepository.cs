using Data.Stocks;
using Domain.Stocks;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Stocks
{
    public sealed class StocksRepository : UniqueEntityRepository<Stock, StockData>, IStocksRepository
    {
        protected internal override Stock ToDomainObject(StockData periodData) => new Stock(periodData);

        public StocksRepository(DbContext c, DbSet<StockData> s) : base(c, s)
        {
        }
    }
}