using Data.ProductTypes;
using Domain.Abstractions;

namespace Domain.CatalogItemTypes
{
    public sealed class CatalogItemType : NamedEntity<ProductTypeData>
    {
        public CatalogItemType() : this(null)
        {
            
        }

        public CatalogItemType(ProductTypeData data) : base(data)
        {
            
        }
    }
}