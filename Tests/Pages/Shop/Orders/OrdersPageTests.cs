using Data.Shop.Orders;
using Domain.Abstractions;
using Domain.Shop.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Pages.Shop.Orders
{
    [TestClass]
    public class OrdersPageTests : SealedClassTests<Order, NamedEntity<OrderData>>
    {
    }
}
