using Aids.Methods;
using Data.Brands;
using Domain.Brands;

namespace Facade.Brands
{
    public class BrandViewFactory 
    {
        public static Brand Create(BrandView view)
        {
            var catalogItemBrandData = new BrandData();
            Copy.Members(view, catalogItemBrandData);
            
            return new Brand(catalogItemBrandData);
        }

        public static BrandView Create(Brand brand)
        {
            var view = new BrandView();
            Copy.Members(brand.Data, view);
            
            return view;
        }
    }
}
