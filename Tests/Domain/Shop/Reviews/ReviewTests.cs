using Data.Shop.Reviews;
using Domain.Abstractions;
using Domain.Shop.Reviews;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Reviews
{
    [TestClass]
    public class ReviewTests : SealedClassTests<Review, UniqueEntity<ReviewData>>
    {
    }
}