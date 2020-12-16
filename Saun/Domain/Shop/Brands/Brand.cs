using Data.Shop.Brands;
using Domain.Abstractions;

namespace Domain.Shop.Brands
{
    public sealed class Brand : DefinedEntity<BrandData>
    {
        public Brand() : this(null)
        {
            
        }

        public Brand(BrandData data) : base(data)
        {
            
        }
    }
}