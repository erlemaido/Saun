using Aids.Reflection;
using Data.Shop.Products;
using Data.Shop.Stock;
using Domain.Shop.Products;
using Domain.Shop.Stock;
using Facade.Shop.Stock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Stock;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Stock
{
    [TestClass]
    public class StockPageTests : SealedViewPageTests<StockPage,
            IStockRepository, global::Domain.Shop.Stock.Stock, StockView, StockData>
    {
        internal class stockRepository : UniqueRepository<global::Domain.Shop.Stock.Stock, StockData>, IStockRepository
        {
            protected override string GetId(StockData d) => d.Id;

        }
        private class productsRepository : UniqueRepository<Product, ProductData>, IProductsRepository
        {
            protected override string GetId(ProductData d) => d.Id;
        }

        private stockRepository Stock;
        private productsRepository Products;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Stock = new stockRepository();
            Products = new productsRepository();
            obj = new StockPage(Stock, Products);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Laoseis", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Stock", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<StockView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<StockView>();
            var view = obj.ToView(StockViewFactory.Create(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetProductNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void ProductsTest()
        {
            Assert.IsNull(null);
        }

        protected override global::Domain.Shop.Stock.Stock CreateObj(StockData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(StockView item)
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

    }

}