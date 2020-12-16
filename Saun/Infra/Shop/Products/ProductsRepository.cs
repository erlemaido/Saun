using Data.Shop.Products;
using Domain.Shop.Products;
using Infra.Abstractions;

namespace Infra.Shop.Products
{
    public sealed class ProductsRepository : UniqueEntityRepository<Product, ProductData>, IProductsRepository
    {
        protected internal override Product ToDomainObject(ProductData data) => new Product(data);

        public ProductsRepository(SaunaDbContext context) : base(context, context.Products)
        {
        }
    }
}