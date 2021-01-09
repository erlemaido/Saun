using System.Linq;
using Aids.Reflection;
using Data.Shop.Brands;
using Data.Shop.People;
using Data.Shop.Products;
using Data.Shop.ProductTypes;
using Data.Shop.Reviews;
using Data.Shop.Stock;
using Data.Shop.Units;
using Domain.Shop.Brands;
using Domain.Shop.Cities;
using Domain.Shop.Countries;
using Domain.Shop.People;
using Domain.Shop.Products;
using Domain.Shop.ProductTypes;
using Domain.Shop.Reviews;
using Domain.Shop.Stock;
using Domain.Shop.Units;
using Facade.Shop.Products;
using Infra.Shop.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Products;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Products
{
    [TestClass]
    public class ProductsPageTests : SealedViewPageTests<ProductsPage,
        IProductsRepository, Product, ProductView, ProductData>
    {

        private ProductsTestRepository _productsTest;
        private StockTestRepository _stockTest;
        private ProductTypesTestRepository _productTypesTest;
        private UnitsTestRepository _unitsTest;
        private BrandsTestRepository _brandsTest;
        private ReviewsTestRepository _reviewsTest;
        private ProductData _data;
        private StockData _stockData;
        private ProductTypeData _productTypeData;
        private BrandData _brandData;
        private ReviewData _reviewData;
        private string _selectedId;
        private UnitData _unitData;
        private IHostingEnvironment _environment;


        protected override string GetId(ProductView item) => item.Id;

        protected override string PageTitle() => PagesNames.Products;

        protected override string PageUrl() => PagesUrls.Products;
        protected override Product CreateObj(ProductData d) => new Product(d);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            _selectedId = GetRandom.String();
            _productsTest = new ProductsTestRepository();
            _stockTest = new StockTestRepository();
            _unitsTest = new UnitsTestRepository();
            _productTypesTest = new ProductTypesTestRepository();
            _brandsTest = new BrandsTestRepository();
            _reviewsTest = new ReviewsTestRepository();
            _data = GetRandom.Object<ProductData>();
            _stockData = GetRandom.Object<StockData>();
            _productTypeData = GetRandom.Object<ProductTypeData>();
            _unitData = GetRandom.Object<UnitData>();
            _brandData = GetRandom.Object<BrandData>();
            _reviewData = GetRandom.Object<ReviewData>();

            AddRandomProducts();
            AddRandomStock();
            AddRandomUnits();
            AddRandomProductTypes();
            AddRandomBrands();
            AddRandomReviews();
            obj = new ProductsPage(_environment, _stockTest,_productsTest,_brandsTest,_productTypesTest,_reviewsTest,_unitsTest);

        }

        private void AddRandomReviews()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _reviewData : GetRandom.Object<ReviewData>();
                _reviewsTest.Add(new Review(d)).GetAwaiter();
            }
        }

        private void AddRandomBrands()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _brandData : GetRandom.Object<BrandData>();
                _brandsTest.Add(new Brand(d)).GetAwaiter();
            }
        }

        private void AddRandomProductTypes()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _productTypeData : GetRandom.Object<ProductTypeData>();
                _productTypesTest.Add(new ProductType(d)).GetAwaiter();
            }
        }

        private void AddRandomUnits()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _unitData : GetRandom.Object<UnitData>();
                _unitsTest.Add(new Unit(d)).GetAwaiter();
            }
        }

        private void AddRandomStock()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _stockData : GetRandom.Object<StockData>();
                _stockTest.Add(new global::Domain.Shop.Stock.Stock(d)).GetAwaiter();
            }
        }

        private void AddRandomProducts()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<ProductData>();
                _productsTest.Add(new Product(d)).GetAwaiter();
            }
        }


        private class ProductsTestRepository
            : UniqueRepository<Product, ProductData>,
                IProductsRepository
        {
            protected override string GetId(ProductData d) => d.Id;

        }

        private class StockTestRepository
            : UniqueRepository<global::Domain.Shop.Stock.Stock, StockData>,
                IStockRepository
        {
            protected override string GetId(StockData d) => d.Id;
        }

        private class UnitsTestRepository
            : UniqueRepository<Unit, UnitData>,
                IUnitsRepository
        {
            protected override string GetId(UnitData d) => d.Id;
        }

        private class ProductTypesTestRepository
            : UniqueRepository<ProductType, ProductTypeData>,
                IProductTypesRepository
        {
            protected override string GetId(ProductTypeData d) => d.Id;
        }

        private class BrandsTestRepository
            : UniqueRepository<Brand, BrandData>,
                IBrandsRepository
        {
            protected override string GetId(BrandData d) => d.Id;
        }

        private class ReviewsTestRepository
            : UniqueRepository<Review, ReviewData>,
                IReviewsRepository
        {
            protected override string GetId(ReviewData d) => d.Id;
        }

        [TestMethod]
        public override void ToObjectTest()

        {
            var view = GetRandom.Object<ProductView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<ProductData>();
            var view = obj.ToView(CreateObj(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void ProductTypesTest()
        {
            var list = _productTypesTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.ProductTypes.Count());
        }

        [TestMethod]
        public void UnitsTest()
        {
            var list = _unitsTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Units.Count());
        }
        [TestMethod]
        public void StockTest()
        {
            var list = _stockTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Stock.Count());
        }

        [TestMethod]
        public void BrandsTest()
        {
            var list = _brandsTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Brands.Count());
        }

        [TestMethod]
        public void ReviewsTest()
        {
            var list = _reviewsTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Reviews.Count());
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod]
        public void GetUnitNameTest()
        {
            var name = obj.GetUnitName(_unitData.Id);
            Assert.AreEqual(_unitData.Code,name);
        }

        [TestMethod]
        public void GetProductTypeNameTest()
        {
            var name = obj.GetProductTypeName(_productTypeData.Id);
            Assert.AreEqual(_productTypeData.Name, name);
        }

        [TestMethod]
        public void GetBrandNameTest()
        {
            var name = obj.GetBrandName(_brandData.Id);
            Assert.AreEqual(_brandData.Name, name);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Tooted", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Products", obj.PageUrl.ToString());
    }

}