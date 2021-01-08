using Data.Shop.OrderStatuses;
using Domain.Abstractions;
using Domain.Shop.OrderStatuses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Pages.Shop.OrderStatuses
{
    [TestClass]
    public class OrderStatusesPageTests : SealedClassTests<OrderStatus, UniqueEntity<OrderStatusData>>
    {
    }
}
