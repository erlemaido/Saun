using Aids.Methods;
using Data.Shop.Products;
using Domain.Shop.Products;

namespace Facade.Shop.Products

{
    public sealed class ProductViewFactory
    {
        public static Product Create(ProductView view)
        {
            var productData = new ProductData();
            Copy.Members(view, productData);
            
            return new Product(productData);
        }

        public static ProductView Create(Product product)
        {
            var view = new ProductView();
            Copy.Members(product.Data, view);

            return view;
        }
    }
}
