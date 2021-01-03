using Data.Shop.OrderItems;
using Domain.Abstractions;
using Domain.Shop.OrderItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.OrderItems
{
    [TestClass]
    public class OrderItemTests : SealedClassTests<OrderItem, UniqueEntity<OrderItemData>>
    {
    }
}
