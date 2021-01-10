using System.Collections.Generic;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.Brands;
using Domain.Shop.Brands;
using Facade.Shop.Brands;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Brands;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Brands
{
    [TestClass]
    public class BrandsPageTests : SealedViewPageTests<BrandsPage, IBrandsRepository, Brand, BrandView, BrandData>
    {
        private TestRepository _repository;

        private class TestRepository
            : UniqueRepository<Brand, BrandData>,
                IBrandsRepository
        {
            protected override string GetId(BrandData d) => d.Id;

            public Task AddAll(List<Brand> obj)
            {
                throw new System.NotImplementedException();
            }
        }
        protected override string GetId(BrandView item) => item.Id;

        protected override string PageTitle() => PagesNames.Brands;

        protected override string PageUrl() => PagesUrls.Brands;
        protected override Brand CreateObj(BrandData d) => new Brand(d);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _repository = new TestRepository();
            obj = new BrandsPage(_repository);
        }


        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<BrandView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<BrandData>();
            var view = obj.ToView(CreateObj(d));
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
        public void PageTitleTest() => Assert.AreEqual("Brändid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Brands", obj.PageUrl.ToString());


    }
}
