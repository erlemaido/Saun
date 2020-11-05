using Domain.Abstractions;
using Data.CatalogItemBrands;

namespace Domain.CatalogItemBrands
{
    public sealed class CatalogItemBrand : DefinedEntity<CatalogItemBrandData>
    {
        public CatalogItemBrand() : this(null)
        {
            
        }

        public CatalogItemBrand(CatalogItemBrandData data) : base(data)
        {
            
        }
    }
}