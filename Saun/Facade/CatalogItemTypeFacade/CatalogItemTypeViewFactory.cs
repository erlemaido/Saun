using System;
using System.Collections.Generic;
using System.Text;
using Aids.Methods;
using Saun.Data.CatalogItem;
using Saun.Data.CatalogItemType;
using Saun.Domain.CatalogItemDomain;
using Saun.Domain.CatalogItemTypeDomain;
using Saun.Facade.CataLogItemFacade;

namespace Saun.Facade.CatalogItemTypeFacade
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
