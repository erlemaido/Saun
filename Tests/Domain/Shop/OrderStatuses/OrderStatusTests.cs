using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.OrderStatuses;
using Domain.Abstractions;

namespace Domain.Shop.OrderStatuses
{
    [TestClass]
    public class OrderStatusTests : SealedClassTests<OrderStatus, UniqueEntity<OrderStatusData>>
    {
    }
}
