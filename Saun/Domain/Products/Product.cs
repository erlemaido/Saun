using Data.Products;
using Domain.Abstractions;

namespace Domain.CatalogItems
{
    public sealed class CatalogItem : UniqueEntity<ProductData>
    {
        public CatalogItem() : this(null)
        {
            
        }

        public CatalogItem(ProductData data) : base(data)
        {
            
        }
    }
}