using Data.Brands;
using Domain.Abstractions;

namespace Domain.Brands
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