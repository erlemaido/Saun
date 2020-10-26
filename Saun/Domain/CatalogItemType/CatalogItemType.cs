using Data.CatalogItemType;
using Domain.Abstractions;

namespace Domain.CatalogItemType
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