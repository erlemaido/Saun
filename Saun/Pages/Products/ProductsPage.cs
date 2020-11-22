using System;
using System.Collections.Generic;
using System.Text;
using Data.Products;
using Facade.Products;
using Domain.Products;

namespace Pages.Products
{
    public class ProductsPage : ViewPage<IProductsRepository, Product, ProductView, ProductData>
    {
        public ProductsPage(IProductsRepository repository) : base(repository, "Brändid")
        {
        }

        protected internal override Product ToObject(ProductView view) => ProductViewFactory.Create(view);

        protected internal override ProductView ToView(Product obj) => ProductViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri("/Products", UriKind.Relative);
    }
}

