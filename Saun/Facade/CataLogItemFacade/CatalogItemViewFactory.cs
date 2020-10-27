using Aids.Methods;
using Saun.Data.CatalogItem;
using Saun.Domain.CatalogItemDomain;

namespace Saun.Facade.CataLogItemFacade

{
    public class CatalogItemViewFactory
    {
        public static CatalogItem Create(CatalogItemView v)
        {
            var d = new CatalogItemData();
            Copy.Members(v, d);
            return new Domain.CatalogItemDomain.CatalogItem(d);

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
