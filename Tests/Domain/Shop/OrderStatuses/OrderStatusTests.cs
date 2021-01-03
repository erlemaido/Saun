using Data.Shop.OrderStatuses;
using Domain.Abstractions;
using Domain.Shop.OrderStatuses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.OrderStatuses
{
    [TestClass]
    public class OrderStatusTests : SealedClassTests<OrderStatus, UniqueEntity<OrderStatusData>>
    {
    }
}
