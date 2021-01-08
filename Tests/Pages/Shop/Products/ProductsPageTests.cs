using Data.Shop.Products;
using Data.Shop.Products;
using Domain.Abstractions;
using Domain.Shop.Products;
using Domain.Shop.Products;
using Facade.Shop.Products;
using Infra.Shop.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Products;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Products
{
    [TestClass]
    public class ProductsPageTests : SealedViewPageTests<ProductsPage,
        IProductsRepository, Product, ProductView, ProductData>
    {

        private ProductsRepository _products;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(ProductView item)
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

        protected override Product CreateObj(ProductData d)
        {
            throw new System.NotImplementedException();
        }
    }

}