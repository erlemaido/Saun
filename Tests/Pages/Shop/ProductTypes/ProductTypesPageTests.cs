using Data.Shop.ProductTypes;
using Data.Shop.ProductTypes;
using Domain.Abstractions;
using Domain.Shop.ProductTypes;
using Domain.Shop.ProductTypes;
using Facade.Shop.ProductTypes;
using Infra.Shop.ProductTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.ProductTypes;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.ProductTypes
{
    [TestClass]
    public class ProductTypesPageTests : SealedViewPageTests<ProductTypesPage,
        IProductTypesRepository, ProductType, ProductTypeView, ProductTypeData>
    {

        private ProductTypesRepository _productTypes;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(ProductTypeView item)
        {
            throw new System.NotImplementedException();
        }

        protected override string PageTitle()
        {
            throw new System.NotImplementedException();
        }

        protected override string PageUrl()
        {
            throw new System.NotImplementedException();
        }

        protected override ProductType CreateObj(ProductTypeData d)
        {
            throw new System.NotImplementedException();
        }
    }

}