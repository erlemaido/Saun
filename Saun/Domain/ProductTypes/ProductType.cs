using Data.ProductTypes;
using Domain.Abstractions;

namespace Domain.ProductTypes
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