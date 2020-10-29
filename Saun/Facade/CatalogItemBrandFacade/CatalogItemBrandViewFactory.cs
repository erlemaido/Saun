using System;
using System.Collections.Generic;
using System.Text;
using Aids.Methods;
using Saun.Data.CatalogItemBrand;
using Saun.Domain.CatalogItemBrandDomain;

namespace Saun.Facade.CatalogItemBrandFacade
{
    public class CatalogItemBrandViewFactory 
    {
        public static CatalogItemBrand Create(CatalogItemBrandView v)
        {
            var d = new CatalogItemBrandData();
            Copy.Members(v, d);
            return new CatalogItemBrand(d);

        }

        public static CatalogItemBrandView Create(CatalogItemBrand o)
        {
            var v = new CatalogItemBrandView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);
            return v;
        }
    }
}
