using System;
using Data.ProductTypes;
using Domain.ProductTypes;
using Facade.ProductTypes;

namespace Pages.CatalogItemTypes
{
    public abstract class CatalogItemTypesPage : CommonPage<IProductTypesRepository, ProductType, ProductTypeView, ProductTypeData>
    {
        protected internal CatalogItemTypesPage(IProductTypesRepository productTypesRepository) : base(
            productTypesRepository)
        {
            PageTitle = "Toote Tüübid";

        }
        public override Guid ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/Saun/CatalogItemTypes";
        //No idea, mis meil siin olema peaks
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
