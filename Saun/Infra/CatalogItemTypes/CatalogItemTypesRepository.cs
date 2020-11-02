using System;
using System.Threading.Tasks;
using Data.CatalogItemTypes;
using Domain.CatalogItemTypes;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.CatalogItemTypes
{
    public sealed class CatalogItemTypesRepository : UniqueEntityRepository<CatalogItemType, CatalogItemTypeData>, ICatalogItemTypesRepository
    {
        protected override Task<CatalogItemTypeData> GetData(Guid id)
        {
            throw new NotImplementedException();
        }

        protected override Task<CatalogItemTypeData> GetStringData(string id)
        {
            throw new NotImplementedException();
        }

        protected override string GetId(CatalogItemType entity)
        {
            throw new NotImplementedException();
        }

        protected internal override CatalogItemType ToDomainObject(CatalogItemTypeData periodData)
        {
            throw new NotImplementedException();
        }

        public CatalogItemTypesRepository(DbContext c, DbSet<CatalogItemTypeData> s) : base(c, s)
        {
        }
    }
}