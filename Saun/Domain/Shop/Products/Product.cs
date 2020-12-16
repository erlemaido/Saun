using Data.Shop.Products;
using Domain.Abstractions;

namespace Domain.Shop.Products
{
    public sealed class Product : UniqueEntity<ProductData>
    {
        public Product() : this(null)
        {
            
        }

        public Product(ProductData data) : base(data)
        {
            
        }
    }
}