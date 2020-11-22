using System;
using Data.ProductTypes;
using Domain.ProductTypes;
using Facade.ProductTypes;
using Pages.Common.Constants;

namespace Pages.ProductTypes
{
    public sealed class ProductTypesPage : ViewsPage<IProductTypesRepository, ProductType, ProductTypeView, ProductTypeData>
    {
        public ProductTypesPage(IProductTypesRepository productTypesRepository) : base(
            productTypesRepository, ProductPagesNames.ProductTypes)
        {

        }
        protected internal override Uri CreatePageUrl() => new Uri(ProductPagesUrls.ProductTypes, UriKind.Relative);

        protected internal override ProductType ToObject(ProductTypeView view)
        {
            return ProductTypeViewFactory.Create(view);
        }

        protected internal override ProductTypeView ToView(ProductType obj)
        {
            return ProductTypeViewFactory.Create(obj);
        }
    }
}
