using Data.Shop.OrderItems;
using Domain.Shop.OrderItems;
using Facade.Shop.OrderItems;
using Infra.Shop.OrderItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.OrderItems;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.OrderItems
{
    [TestClass]
    public class OrderItemsPageTests : SealedViewPageTests<OrderItemsPage,
            IOrderItemsRepository, OrderItem, OrderItemView, OrderItemData>
    {

        private OrderItemsRepository OrderItems;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(OrderItemView item)
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

        protected override OrderItem CreateObj(OrderItemData d)
        {
            throw new System.NotImplementedException();
        }
    }

}
