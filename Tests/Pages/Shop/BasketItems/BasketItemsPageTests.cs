using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Baskets;
using Data.Shop.Products;
using Data.Shop.ProductTypes;
using Data.Shop.Units;
using Domain.Shop.BasketItems;
using Domain.Shop.Baskets;
using Domain.Shop.Products;
using Facade.Shop.BasketItems;
using Facade.Shop.Products;
using Infra.Shop.Baskets;
using Infra.Shop.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.BasketItems;
using Sauna.Pages.Shop.Products;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.BasketItems
{
    [TestClass]
    public class BasketItemsPageTests : SealedViewPageTests<BasketItemsPage, IBasketItemsRepository, BasketItem,
        BasketItemView, BasketItemData>
    {
        private TestRepository _repository;
        private ProductTestRepository _productsTest;
        private BasketTestRepository _basketsTest;
        private BasketItemData _data;
        private ProductData _productData;
        private BasketData _basketData;
        private string _selectedId;
        protected override string GetId(BasketItemView item) => item.Id;

        protected override string PageTitle() => PagesNames.BasketItems;

        protected override string PageUrl() => PagesUrls.BasketItems;
        protected override BasketItem CreateObj(BasketItemData d) => new BasketItem(d);
        private bool IsBasket() => obj.FixedFilter == GetMember.Name<BasketItemView>(x => x.BasketId);

        private bool IsProduct() => obj.FixedFilter == GetMember.Name<BasketItemView>(x => x.ProductId);


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            _selectedId = GetRandom.String();
            _repository = new TestRepository();
            _productsTest = new ProductTestRepository();
            _basketsTest = new BasketTestRepository();
            _data = GetRandom.Object<BasketItemData>();
            _productData = GetRandom.Object<ProductData>();
            _basketData = GetRandom.Object<BasketData>();
            AddRandomBasketItems();
            AddRandomProducts();
            AddRandomBaskets();
            obj = new BasketItemsPage(_repository, _basketsTest, _productsTest);

        }

        private void AddRandomBaskets()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _basketData : GetRandom.Object<BasketData>();
                _basketsTest.Add(new Basket(d)).GetAwaiter();
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

        private void AddRandomBasketItems()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<BasketItemData>();
                _repository.Add(new BasketItem(d)).GetAwaiter();
            }
        }

        private class TestRepository
            : UniqueRepository<BasketItem, BasketItemData>,
                IBasketItemsRepository
        {
            protected override string GetId(BasketItemData d) => d.Id;

            public Task AddAll(List<BasketItem> obj)
            {
                throw new NotImplementedException();
            }
        }

        private class ProductTestRepository
            : UniqueRepository<Product, ProductData>,
                IProductsRepository
        {
            protected override string GetId(ProductData d) => d.Id;
            public Task AddAll(List<Product> obj)
            {
                throw new NotImplementedException();
            }
        }

        private class BasketTestRepository
            : UniqueRepository<Basket, BasketData>,
                IBasketsRepository
        {
            protected override string GetId(BasketData d) => d.Id;
            public Task AddAll(List<Basket> obj)
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public override void ToObjectTest()

        {
            var view = GetRandom.Object<BasketItemView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<BasketItemData>();
            var view = obj.ToView(CreateObj(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void ProductsTest()
        {
            var list = _productsTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Products.Count());
        }

        [TestMethod]
        public void BasketsTest()
        {
            var list = _basketsTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Baskets.Count());
        }


        [TestMethod]
        public void GetProductNameTest()
        {
            var name = obj.GetProductName(_productData.Id);
            Assert.AreEqual(_productData.Name, name);
        }

        [TestMethod]
        public void GetBasketNameTest()
        {
            var name = obj.GetBasketName(_basketData.Id);
            Assert.AreEqual(_basketData.Name, name);
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Ostukorvi read", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/BasketItems", obj.PageUrl.ToString());

        [TestMethod]
        public void GetPageBasketSubtitleTest()
        {
            var list = _basketsTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<BasketItemView>(x => x.BasketId);
            if (!IsBasket()) return;
            foreach (var basket in list.Where(basket => basket.Id == _basketData.Id))
            {
                obj.FixedValue = basket.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }

        }

        [TestMethod]
        public void GetPageProductSubtitleTest()
        {
            var list = _productsTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<BasketItemView>(x => x.ProductId);
            if (!IsProduct()) return;
            foreach (var product in list.Where(product => product.Id == _productData.Id))
            {
                obj.FixedValue = product.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }

        }

    }

}

