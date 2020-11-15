using System;
using System.Collections.Generic;
using System.Text;
using Data.Products;
using Facade.Products;
using Domain.Products;

namespace Pages.Products
{
    class ProductsPage : CommonPage<IProductsRepository, Product, ProductView, ProductData>
    {
        protected internal ProductsPage(IProductsRepository ProductsRepository) : base(
            ProductsRepository)
        {
            PageTitle = "Tooted";
        }

        public override Guid ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/Saun/Products";

        protected internal override Product ToObject(ProductView view)
        {
            return ProductViewFactory.Create(view);
        }

        protected internal override ProductView ToView(Product obj)
        {
            return ProductViewFactory.Create(obj);
        }
    }
}
