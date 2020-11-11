using Domain.Abstractions;
using Domain.Products;

namespace Domain.CatalogItems
{
    public interface ICatalogItemsRepository : IRepository<Product>
    {
        
    }
}