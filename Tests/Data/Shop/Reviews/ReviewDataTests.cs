using Data.Abstractions;
using Data.Shop.Reviews;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.Reviews
{
    [TestClass]
    public class ReviewDataTests : SealedClassTests<ReviewData, UniqueEntityData>
    {
        [TestMethod]
        public void ProductIdTest()
        {
            IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);
        }

        [TestMethod]
        public void UserIdTest()
        {
            IsNullableProperty(() => obj.UserId, x => obj.UserId = x);
        }

        [TestMethod]
        public void RatingTest()
        {
            IsProperty(() => obj.Rating, x => obj.Rating = x);
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
