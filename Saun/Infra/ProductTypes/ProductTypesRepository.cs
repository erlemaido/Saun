using Data.ProductTypes;
using Domain.ProductTypes;
using Infra.Abstractions;

namespace Infra.ProductTypes
{
    public sealed class ProductTypesRepository : UniqueEntityRepository<ProductType, ProductTypeData>, IProductTypesRepository
    {
        protected internal override ProductType ToDomainObject(ProductTypeData data) => new ProductType(data);

        public ProductTypesRepository(SaunaDbContext context) : base(context, context.ProductTypes)
        {
        }
    }
}