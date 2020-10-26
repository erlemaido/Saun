using Domain.Abstractions;
using Data.CatalogItem;

namespace Domain.CatalogItem
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