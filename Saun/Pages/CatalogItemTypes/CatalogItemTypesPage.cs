using System;
using Data.CatalogItemTypes;
using Domain.CatalogItemTypes;
using Facade.CatalogItemTypes;

namespace Pages.CatalogItemTypes
{
    public abstract class CatalogItemTypesPage : CommonPage<ICatalogItemTypesRepository, CatalogItemType, CatalogItemTypeView, CatalogItemTypeData>
    {
        protected internal CatalogItemTypesPage(ICatalogItemTypesRepository catalogItemTypesRepository) : base(
            catalogItemTypesRepository)
        {
            PageTitle = "Toote Tüübid";

        }
        public override Guid ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/Saun/CatalogItemTypes";
        //No idea, mis meil siin olema peaks
        protected internal override CatalogItemType ToObject(CatalogItemTypeView view)
        {
            return CatalogItemTypeViewFactory.Create(view);
        }

        protected internal override CatalogItemTypeView ToView(CatalogItemType obj)
        {
            return CatalogItemTypeViewFactory.Create(obj);
        }
    }
}
