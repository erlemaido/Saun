using Data.CatalogItemTypes;
using Domain.CatalogItemTypes;
using Infra.Abstractions;

namespace Infra.CatalogItemTypes
{
    public sealed class CatalogItemTypesRepository : UniqueEntityRepository<CatalogItemType, CatalogItemTypeData>, ICatalogItemTypesRepository
    {
        
    }
}