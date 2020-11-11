using Data.Brands;
using Domain.Abstractions;

namespace Domain.CatalogItemBrands
{
    public sealed class CatalogItemBrand : DefinedEntity<BrandData>
    {
        public CatalogItemBrand() : this(null)
        {
            
        }

        public CatalogItemBrand(BrandData data) : base(data)
        {
            
        }
    }
}