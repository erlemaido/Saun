using Data.CatalogItemBrand;
using Domain.Abstractions;

namespace Domain.CatalogItemBrand
{
    public sealed class CatalogItemBrand : DefinedEntity<CatalogItemBrandData>
    {
        public CatalogItemBrand() : this(null!)
        {
            
        }

        public CatalogItemBrand(CatalogItemBrandData data) : base(data)
        {
            
        }
        
    }
}