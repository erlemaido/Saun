﻿using Facade.Abstractions;
using Facade.Shop.Reviews;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Reviews
{
    [TestClass]
    public class ReviewViewTests : SealedClassTests<ReviewView, UniqueEntityView>
    {
        [TestMethod]
        public void ProductIdTest() => IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);

        [TestMethod]
        public void UserIdTest() => IsNullableProperty(() => obj.UserId, x => obj.UserId = x);

        [TestMethod]
        public void RatingTest() => IsProperty(() => obj.Rating, x => obj.Rating = x);

        [TestMethod]
        public void CommentTest() => IsNullableProperty(() => obj.Comment, x => obj.Comment = x);

        [TestMethod]
        public void TimeTest() => IsProperty(() => obj.Time, x => obj.Time = x);
    }
}
