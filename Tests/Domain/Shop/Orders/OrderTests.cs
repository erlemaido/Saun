using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.Orders;
using Domain.Abstractions;

namespace Domain.Shop.Orders
{
    [TestClass]
    public class OrderTests : SealedClassTests<Order, NamedEntity<OrderData>>
    {
    }
}
