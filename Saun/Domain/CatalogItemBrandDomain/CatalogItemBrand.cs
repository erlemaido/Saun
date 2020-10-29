using Saun.Data.CatalogItemBrand;
using Saun.Domain.Abstractions;

namespace Saun.Domain.CatalogItemBrandDomain
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