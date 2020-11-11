using Aids.Methods;
using Data.ProductTypes;
using Domain.ProductTypes;
using Facade.ProductTypes;

namespace Facade.CatalogItemTypes
{
    public class CatalogItemTypeViewFactory
    {
        public static ProductType Create(ProductTypeView view)
        {
            var catalogItemTypeData = new ProductTypeData();
            Copy.Members(view, catalogItemTypeData);
            
            return new ProductType(catalogItemTypeData);
        }

        public static ProductTypeView Create(ProductType productType)
        {
            var view = new ProductTypeView();
            Copy.Members(productType.Data, view);

            return view;
        }
    }
}
