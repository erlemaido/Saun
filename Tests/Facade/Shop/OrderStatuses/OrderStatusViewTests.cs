using Facade.Abstractions;
using Facade.Shop.OrderStatuses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.OrderStatuses
{
    [TestClass]
    public class OrderStatusViewTests : SealedClassTests<OrderStatusView, UniqueEntityView>
    {
        [TestMethod]
        public void OrderIdTest() => IsNullableProperty(() => obj.OrderId, x => obj.OrderId = x);

        [TestMethod]
        public void StatusIdTest() => IsNullableProperty(() => obj.StatusId, x => obj.StatusId = x);

        [TestMethod]
        public void TimeTest() => IsProperty(() => obj.Time, x => obj.Time = x);

        [TestMethod]
        public void CommentTest() => IsNullableProperty(() => obj.Comment, x => obj.Comment = x);
    }
}
