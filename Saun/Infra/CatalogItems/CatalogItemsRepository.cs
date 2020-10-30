using Data.CatalogItems;
using Domain.CatalogItems;
using Infra.Abstractions;

namespace Infra.CatalogItems
{
    public sealed class CatalogItemsRepository : UniqueEntityRepository<CatalogItem, CatalogItemData>, ICatalogItemsRepository
    {
        
    }
}