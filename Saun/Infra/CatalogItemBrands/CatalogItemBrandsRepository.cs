using Data.CatalogItemBrands;
using Domain.CatalogItemBrands;
using Infra.Abstractions;

namespace Infra.CatalogItemBrands
{
    public sealed class CatalogItemBrandsRepository : UniqueEntityRepository<CatalogItemBrand, CatalogItemBrandData>, ICatalogItemBrandsRepository
    {
        
    }
}