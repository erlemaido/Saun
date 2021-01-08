using Data.Abstractions;
using Data.Shop.OrderStatuses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.OrderStatuses
{
    [TestClass]
    public class OrderStatusDataTests : SealedClassTests<OrderStatusData, UniqueEntityData>
    {
        [TestMethod]
        public void OrderIdTest()
        {
            IsNullableProperty(() => obj.OrderId, x => obj.OrderId = x);
        }

        [TestMethod]
        public void StatusIdTest()
        {
            IsNullableProperty(() => obj.StatusId, x => obj.StatusId = x);
        }

        [TestMethod]
        public void CommentTest()
        {
            IsNullableProperty(() => obj.Comment, x => obj.Comment = x);
        }

        [TestMethod]
        public void TimeTest()
        {
            IsProperty(() => obj.Time, x => obj.Time = x);
        }
    }
}
    
