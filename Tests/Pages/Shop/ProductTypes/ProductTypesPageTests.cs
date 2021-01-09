using Aids.Reflection;
using Data.Shop.OrderStatuses;
using Data.Shop.ProductTypes;
using Domain.Shop.OrderStatuses;
using Domain.Shop.ProductTypes;
using Facade.Shop.ProductTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.ProductTypes;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.ProductTypes
{
    [TestClass]
    public class ProductTypesPageTests : SealedViewsPageTests<ProductTypesPage,
            IProductTypesRepository, ProductType, ProductTypeView, ProductTypeData>
    {
        internal class ProductTypesTestRepository : UniqueRepository<ProductType, ProductTypeData>, IProductTypesRepository
        {
            protected override string GetId(ProductTypeData d) => d.Id;

        }

        private ProductTypesTestRepository _productTypesTest;

        protected override string GetId(ProductTypeView item) => item.Id;

        protected override string PageTitle() => PagesNames.PaymentTypes;

        protected override string PageUrl() => PagesUrls.ProductTypes;
        protected override ProductType CreateObj(ProductTypeData d) => new ProductType(d);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _productTypesTest = new ProductTypesTestRepository();
            obj = new ProductTypesPage(_productTypesTest);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Toote tüübid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/ProductTypes", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<ProductTypeView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<ProductTypeView>();
            var view = obj.ToView(ProductTypeViewFactory.Create(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }


    }

}