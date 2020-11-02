using System;
using System.Threading.Tasks;
using Data.CatalogItems;
using Domain.CatalogItems;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.CatalogItems
{
    public sealed class CatalogItemsRepository : UniqueEntityRepository<CatalogItem, CatalogItemData>, ICatalogItemsRepository
    {
        protected override Task<CatalogItemData> GetData(Guid id)
        {
            throw new NotImplementedException();
        }

        protected override Task<CatalogItemData> GetStringData(string id)
        {
            throw new NotImplementedException();
        }

        protected override string GetId(CatalogItem entity)
        {
            throw new NotImplementedException();
        }

        protected internal override CatalogItem ToDomainObject(CatalogItemData periodData)
        {
            throw new NotImplementedException();
        }

        public CatalogItemsRepository(DbContext c, DbSet<CatalogItemData> s) : base(c, s)
        {
        }
    }
}