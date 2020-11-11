using Data.ProductTypes;
using Domain.ProductTypes;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.CatalogItemTypes
{
    public sealed class ProductTypesRepository : UniqueEntityRepository<ProductType, ProductTypeData>, IProductTypesRepository
    {
        protected internal override ProductType ToDomainObject(ProductTypeData uniqueEntityData) => new ProductType(uniqueEntityData);

        public ProductTypesRepository(SaunDbContext c) : base(c, c.CatalogItemTypes)
        {
        }
    }
}