using Aids.Methods;
using Data.CatalogItems;
using Domain.CatalogItems;

namespace Facade.CatalogItems

{
    public class CatalogItemViewFactory
    {
        public static CatalogItem Create(CatalogItemView view)
        {
            var catalogItemData = new CatalogItemData();
            Copy.Members(view, catalogItemData);
            
            return new CatalogItem(catalogItemData);
        }

        public static CatalogItemView Create(CatalogItem catalogItem)
        {
            var view = new CatalogItemView();
            Copy.Members(catalogItem.Data, view);

            return view;
        }
    }
}
