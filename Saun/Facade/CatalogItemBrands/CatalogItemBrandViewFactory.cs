using Aids.Methods;
using Data.CatalogItemBrands;
using Domain.CatalogItemBrands;

namespace Facade.CatalogItemBrands
{
    public class CatalogItemBrandViewFactory 
    {
        public static CatalogItemBrand Create(CatalogItemBrandView view)
        {
            var catalogItemBrandData = new CatalogItemBrandData();
            Copy.Members(view, catalogItemBrandData);
            
            return new CatalogItemBrand(catalogItemBrandData);
        }

        public static CatalogItemBrandView Create(CatalogItemBrand catalogItemBrand)
        {
            var view = new CatalogItemBrandView();
            Copy.Members(catalogItemBrand.Data, view);
            
            return view;
        }
    }
}
