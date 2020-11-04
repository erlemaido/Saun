using Data.CatalogItems;
using Domain.CatalogItems;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.CatalogItems
{
    public sealed class CatalogItemsRepository : UniqueEntityRepository<CatalogItem, CatalogItemData>, ICatalogItemsRepository
    {
        protected internal override CatalogItem ToDomainObject(CatalogItemData periodData) => new CatalogItem(periodData);

        public CatalogItemsRepository(DbContext c, DbSet<CatalogItemData> s) : base(c, s)
        {
        }
    }
}