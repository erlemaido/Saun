using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class BasketItemsPageTests :SealedViewPageTests<BasketItemsPage, IBasketItemsRepository,BasketItem, BasketItemView,BasketItemData>
    {
        //private TestRepository repository;
        //private ProductRepository Products;
        //private BasketRepository Baskets;
        private BasketItemData data;
        private ProductData productData;
        private BasketData basketData;
        private string SelectedId;
        protected override string GetId(BasketItemView item) => item.Id;

        protected override string PageTitle() => PagesNames.BasketItems;

        protected override string PageUrl() => PagesUrls.BasketItems;
        protected override BasketItem CreateObj(BasketItemData d) => new BasketItem(d);
        
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            SelectedId = GetRandom.String();
            //repository = new TestRepository();
            //Products = new productRepository();;
            //Baskets = new basketRepository();
            data = GetRandom.Object<BasketItemData>();
            productData = GetRandom.Object<ProductData>();
            basketData = GetRandom.Object<BasketData>();
            AddRandomBasketItems();
            AddRandomProducts();
            AddRandomBaskets();
            //obj = new BasketItemsPage(repository,Baskets, Products );
        }
        private void AddRandomBaskets()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? basketData : GetRandom.Object<BasketData>();
                //Baskets.Add(new Basket(d)).GetAwaiter();
            }
        }

        private void AddRandomProducts()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? productData : GetRandom.Object<ProductData>();
                //Products.Add(new Product(d)).GetAwaiter();
            }
        }
        private void AddRandomBasketItems()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? data : GetRandom.Object<BasketItemData>();
                //repository.Add(new BasketItem(d)).GetAwaiter();
            }
        }
        //private class TestRepository
        //    : UniqueRepository<BasketItem, BasketItemData>,
        //        IBasketItemsRepository
        //{
        //    protected override string GetId(BasketItemData d) => d.Id;
            
        //}
        //private class productRepository
        //    : UniqueRepository<Product, ProductData>,
        //        IProductsRepository
        //{
        //    protected override string GetId(ProductData d) => d.Id;
        //}
        //private class basketRepository
        //    : UniqueRepository<Basket, BasketData>,
        //        IBasketsRepository
        //{
        //    protected override string GetId(BasketData d) => d.Id;
        //}
        [TestMethod] public override void ToObjectTest()
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
        //[TestMethod]
        //public void ProductsTest()
        //{
        //    var list = Products.Get().GetAwaiter().GetResult();
        //    Assert.AreEqual(list.Count, obj.Products.Count());
        //}

        //[TestMethod]
        //public void BasketsTest()
        //{
        //    var list = Baskets.Get().GetAwaiter().GetResult();
        //    Assert.AreEqual(list.Count, obj.Baskets.Count());
        //}
        [TestMethod]
        public void GetProductNameTest()
        {
            var name = obj.GetProductName(productData.Id);
            Assert.AreEqual(productData.Name, name);
        }

        [TestMethod]
        public void GetBasketNameTest()
        {
            var name = obj.GetBasketName(basketData.Id);
            Assert.AreEqual(basketData.Name, name);
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

    }
}
