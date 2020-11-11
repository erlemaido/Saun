using Data.Products;
using Domain.Products;
using Infra.Abstractions;

namespace Infra.Products
{
    public sealed class ProductsRepository : UniqueEntityRepository<Product, ProductData>, IProductsRepository
    {
        protected internal override Product ToDomainObject(ProductData data) => new Product(data);

        public ProductsRepository(SaunaDbContext context) : base(context, context.Products)
        {
        }
    }
}