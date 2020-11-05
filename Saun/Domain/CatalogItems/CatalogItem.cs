using Data.CatalogItems;
using Domain.Abstractions;

namespace Domain.CatalogItems
{
    public sealed class CatalogItem : UniqueEntity<CatalogItemData>
    {
        public CatalogItem() : this(null)
        {
            
        }

        public CatalogItem(CatalogItemData data) : base(data)
        {
            
        }
    }
}