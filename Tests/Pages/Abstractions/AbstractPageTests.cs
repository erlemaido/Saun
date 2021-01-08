using Data.Shop.Products;
using Domain.Shop.Products;
using Facade.Shop.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions;

namespace Tests.Pages.Abstractions
{

    [TestClass]
    public abstract class AbstractPageTests<TClass, TBaseClass> : AbstractClassTests<TClass, TBaseClass>
        where TClass : BasePage<IProductsRepository, Product, ProductView, ProductData>
    {

        internal TestRepository db;
        internal class TestClass : BasePage<IProductsRepository, Product, ProductView, ProductData>
        {
            protected internal TestClass(IProductsRepository r) : base(r)
            {
                //PageTitle = "Tooted";
            }

            //public string ItemId => Item is null ? string.Empty : Item.GetId();

            protected internal string GetPageUrl() => "/Product/Products";

            protected internal override void SetPageValues(string sortOrder, string searchString, in int? pageIndex)
            {
                throw new System.NotImplementedException();
            }

            protected internal Product ToObject(ProductView view) => ProductViewFactory.Create(view);

            protected internal ProductView ToView(Product obj) => ProductViewFactory.Create(obj);

        }

        internal class TestRepository : BaseTestRepositoryForUniqueEntity<Product, ProductData>, IProductsRepository
        {
            public string CurrentFilter { get; set; }
            public object GetById(string id)
            {
                throw new System.NotImplementedException();
            }
            
            protected override string GetId(OrderData d) => d.Id;

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            db = new TestRepository();
        }
    }
}