using Data.Shop.Orders;
using Domain.Abstractions;
using Domain.Shop.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Orders
{
    [TestClass]
    public class OrderTests : SealedClassTests<Order, NamedEntity<OrderData>>
    {
    }
}
