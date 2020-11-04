using Data.CatalogItemTypes;
using Domain.CatalogItemTypes;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.CatalogItemTypes
{
    public sealed class CatalogItemTypesRepository : UniqueEntityRepository<CatalogItemType, CatalogItemTypeData>, ICatalogItemTypesRepository
    {
        protected internal override CatalogItemType ToDomainObject(CatalogItemTypeData periodData) => new CatalogItemType(periodData);

        public CatalogItemTypesRepository(DbContext c, DbSet<CatalogItemTypeData> s) : base(c, s)
        {
        }
    }
}