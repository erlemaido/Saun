using Data.Shop.Brands;
using Domain.Shop.Brands;
using Infra.Abstractions;

namespace Infra.Shop.Brands
{
    public sealed class BrandsRepository : UniqueEntityRepository<Brand, BrandData>, IBrandsRepository
    {
        protected internal override Brand ToDomainObject(BrandData data) => new Brand(data);

        public BrandsRepository(SaunaDbContext context) : base(context, context.Brands)
        {
        }
    }
}