using System;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Facade.Shop.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Tests.Pages.Abstractions {

    public abstract class AbstractPageTests<TClass, TBaseClass> : AbstractClassTests<TClass, TBaseClass>
        where TClass : BasePage<IOrdersRepository, Order, OrderView, OrderData> {

        internal TestRepository db; 
        internal class TestClass : ViewsPage<IOrdersRepository, Order, OrderView, OrderData> {

            internal string SubTitle { get; set; } = string.Empty;

            protected internal TestClass(IOrdersRepository r) : base(r, PagesNames.Orders) { }
            
            protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Orders, UriKind.Relative);

            protected internal override Order ToObject(OrderView view) => OrderViewFactory.Create(view);

            protected internal override OrderView ToView(Order obj) => OrderViewFactory.Create(obj);

            protected internal override string GetPageSubtitle() => SubTitle;

             
        }

        internal class TestRepository : BaseTestRepositoryForUniqueEntity<Order, OrderData>, IOrdersRepository
        {
            public string CurrentFilter { get; set; }
            
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
