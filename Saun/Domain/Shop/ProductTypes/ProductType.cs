using Data.Shop.ProductTypes;
using Domain.Abstractions;

namespace Domain.Shop.ProductTypes
{
    public sealed class ProductType : NamedEntity<ProductTypeData>
    {
        public ProductType() : this(null)
        {
            
        }

        public ProductType(ProductTypeData data) : base(data)
        {
            
        }
    }
}