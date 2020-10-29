using Saun.Data.CatalogItem;
using Saun.Domain.Abstractions;

namespace Saun.Domain.CatalogItemDomain
{
    public sealed class CatalogItem : UniqueEntity<CatalogItemData>
    {
        public CatalogItem() : this(null!)
        {
            
        }

        public CatalogItem(CatalogItemData data) : base(data)
        {
            
        }
        
    }
}