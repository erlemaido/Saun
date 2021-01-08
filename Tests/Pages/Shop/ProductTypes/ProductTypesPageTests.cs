using Aids.Reflection;
using Data.Shop.ProductTypes;
using Domain.Shop.ProductTypes;
using Facade.Shop.ProductTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.ProductTypes;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.ProductTypes
{
    [TestClass]
    public class ProductTypesPageTests : SealedViewsPageTests<ProductTypesPage,
            IProductTypesRepository, ProductType, ProductTypeView, ProductTypeData>
    {
        internal class productTypesRepository : UniqueRepository<ProductType, ProductTypeData>, IProductTypesRepository
        {
            protected override string GetId(ProductTypeData d) => d.Id;

        }

        private productTypesRepository ProductTypes;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            ProductTypes = new productTypesRepository();
            obj = new ProductTypesPage(ProductTypes);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Toote t��bid", obj.PageTitle);

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
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetPersonNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void PeopleTest()
        {
            Assert.IsNull(null);
        }

        protected override ProductType CreateObj(ProductTypeData d)
        {
            throw new System.NotImplementedException();
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

    }

}