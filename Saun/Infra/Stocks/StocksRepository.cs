using System;
using System.Threading.Tasks;
using Data.Stocks;
using Domain.Stocks;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Stocks
{
    public sealed class StocksRepository : UniqueEntityRepository<Stock, StockData>, IStocksRepository
    {
        protected override Task<StockData> GetData(Guid id)
        {
            throw new NotImplementedException();
        }

        protected override Task<StockData> GetStringData(string id)
        {
            throw new NotImplementedException();
        }

        protected override string GetId(Stock entity)
        {
            throw new NotImplementedException();
        }

        protected internal override Stock ToDomainObject(StockData periodData)
        {
            throw new NotImplementedException();
        }

        public StocksRepository(DbContext c, DbSet<StockData> s) : base(c, s)
        {
        }
    }
}