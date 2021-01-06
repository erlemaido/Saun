using Data.Shop.Orders;
using Domain.Shop.Orders;
using Facade.Shop.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions;

namespace Tests.Pages.Abstractions {

    [TestClass] public class ViewsPageTests : AbstractPageTests<
        ViewsPage<IOrdersRepository, Order, OrderView, OrderData>,
        ViewPage<IOrdersRepository, Order, OrderView, OrderData>> {

        private TestRepository _repository;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _repository = new TestRepository();
            obj = new TestClass(_repository);
        }
    }

}
