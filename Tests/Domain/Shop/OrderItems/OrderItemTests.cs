using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.OrderItems;
using Domain.Abstractions;

namespace Domain.Shop.OrderItems
{
    [TestClass]
    public class OrderItemTests : SealedClassTests<OrderItem, UniqueEntity<OrderItemData>>
    {
    }
}
