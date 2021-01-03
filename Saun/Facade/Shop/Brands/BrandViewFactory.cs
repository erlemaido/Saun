using Aids.Methods;
using Data.Shop.Brands;
using Domain.Shop.Brands;

namespace Facade.Shop.Brands
{
    public sealed class BrandViewFactory 
    {
        public static Brand Create(BrandView view)
        {
            var catalogItemBrandData = new BrandData();
            // {
            //     Id = view.Id ?? Guid.NewGuid().ToString(),
            //     Description = view.Description,
            //     Name = view.Name
            // };
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
