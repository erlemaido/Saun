using System.Linq;
using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Products;
using Data.Shop.Stock;
using Domain.Shop.BasketItems;
using Domain.Shop.Products;
using Domain.Shop.Stock;
using Facade.Shop.Stock;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Stock;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Stock
{
    [TestClass]
    public class StockPageTests : SealedViewPageTests<StockPage,
            IStockRepository, global::Domain.Shop.Stock.Stock, StockView, StockData>
    {
        internal class StockTestRepository : UniqueRepository<global::Domain.Shop.Stock.Stock, StockData>, IStockRepository
        {
            protected override string GetId(StockData d) => d.Id;

        }
        private class ProductTestRepository : UniqueRepository<Product, ProductData>, IProductsRepository
        {
            protected override string GetId(ProductData d) => d.Id;
        }

        private StockTestRepository _stockTest;
        private ProductTestRepository _productsTest;
        private StockData _data;
        private ProductData _productData;
        protected override string GetId(StockView item) => item.Id;

        protected override string PageTitle() => PagesNames.Stock;

        protected override string PageUrl() => PagesUrls.Stock;
        protected override global::Domain.Shop.Stock.Stock CreateObj(StockData d) => new global::Domain.Shop.Stock.Stock(d);


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _stockTest = new StockTestRepository();
            _productsTest = new ProductTestRepository();
            _data = GetRandom.Object<StockData>();
            _productData = GetRandom.Object<ProductData>();
            AddRandomStock();
            AddRandomProducts();
            obj = new StockPage(_stockTest, _productsTest);
        }

        private void AddRandomStock()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<StockData>();
                _stockTest.Add(new global::Domain.Shop.Stock.Stock(d)).GetAwaiter();
            }
        }

        private void AddRandomProducts()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _productData : GetRandom.Object<ProductData>();
                _productsTest.Add(new Product(d)).GetAwaiter();
            }
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
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod]
        public void GetProductNameTest()
        {
            var name = obj.GetProductName(_productData.Id);
            Assert.AreEqual(_productData.Name, name);
        }
        [TestMethod]
        public void ProductsTest()
        {
            var list = _productsTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Products.Count());
        }

       

    }

}