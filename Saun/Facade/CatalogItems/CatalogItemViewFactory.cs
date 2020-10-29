using Aids.Methods;
using Data.CatalogItems;
using Domain.CatalogItems;

namespace Facade.CatalogItems

{
    public class CatalogItemViewFactory
    {
        public static CatalogItem Create(CatalogItemView v)
        {
            var d = new CatalogItemData();
            Copy.Members(v, d);
            return new CatalogItem(d);

        }

        public static CatalogItemView Create(CatalogItem o)
        {
            var v = new CatalogItemView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
