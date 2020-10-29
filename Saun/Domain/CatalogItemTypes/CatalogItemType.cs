using Data.CatalogItemTypes;
using Domain.Abstractions;

namespace Domain.CatalogItemTypes
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