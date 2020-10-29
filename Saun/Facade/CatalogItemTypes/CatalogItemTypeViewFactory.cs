using Aids.Methods;
using Data.CatalogItemTypes;
using Domain.CatalogItemTypes;

namespace Facade.CatalogItemTypes
{
    public class CatalogItemTypeViewFactory
    {
        public static CatalogItemType Create(CatalogItemTypeView v)
        {
            var d = new CatalogItemTypeData();
            Copy.Members(v, d);
            return new CatalogItemType(d);

        }

        public static CatalogItemTypeView Create(CatalogItemType o)
        {
            var v = new CatalogItemTypeView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
