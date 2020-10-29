using Saun.Data.CatalogItemType;
using Saun.Domain.Abstractions;

namespace Saun.Domain.CatalogItemTypeDomain
{
    public sealed class CatalogItemType : NamedEntity<CatalogItemTypeData>
    {
        public CatalogItemType() : this(null!)
        {
            
        }

        public CatalogItemType(CatalogItemTypeData data) : base(data)
        {
            
        }
        
    }
}