using Data.Products;
using Domain.Products;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.CatalogItems
{
    public sealed class ProductsRepository : UniqueEntityRepository<Product, ProductData>, IProductsRepository
    {
        protected internal override Product ToDomainObject(ProductData uniqueEntityData) => new Product(uniqueEntityData);

        public ProductsRepository(SaunDbContext c) : base(c, c.CatalogItems)
        {
        }
    }
}