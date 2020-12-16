using Aids.Methods;
using Data.Shop.ProductTypes;
using Domain.Shop.ProductTypes;

namespace Facade.Shop.ProductTypes
{
    public class ProductTypeViewFactory
    {
        public static ProductType Create(ProductTypeView view)
        {
            var productTypeData = new ProductTypeData();
            Copy.Members(view, productTypeData);
            
            return new ProductType(productTypeData);
        }

        public static ProductTypeView Create(ProductType productType)
        {
            var view = new ProductTypeView();
            Copy.Members(productType.Data, view);

            return view;
        }
    }
}
