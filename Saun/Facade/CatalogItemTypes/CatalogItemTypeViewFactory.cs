using Aids.Methods;
using Data.CatalogItemTypes;
using Domain.CatalogItemTypes;

namespace Facade.CatalogItemTypes
{
    public class CatalogItemTypeViewFactory
    {
        public static CatalogItemType Create(CatalogItemTypeView view)
        {
            var catalogItemTypeData = new CatalogItemTypeData();
            Copy.Members(view, catalogItemTypeData);
            
            return new CatalogItemType(catalogItemTypeData);
        }

        public static CatalogItemTypeView Create(CatalogItemType catalogItemType)
        {
            var view = new CatalogItemTypeView();
            Copy.Members(catalogItemType.Data, view);

            return view;
        }
    }
}
