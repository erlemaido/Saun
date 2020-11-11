using Aids.Methods;
using Data.Products;
using Domain.Products;
using Facade.Products;

namespace Facade.CatalogItems

{
    public class CatalogItemViewFactory
    {
        public static Product Create(ProductView view)
        {
            var catalogItemData = new ProductData();
            Copy.Members(view, catalogItemData);
            
            return new Product(catalogItemData);
        }

        public static ProductView Create(Product product)
        {
            var view = new ProductView();
            Copy.Members(product.Data, view);

            return view;
        }
    }
}
