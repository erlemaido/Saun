using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.Reviews;
using Domain.Abstractions;

namespace Domain.Shop.Reviews
{
    [TestClass]
    public class ReviewTests : SealedClassTests<Review, UniqueEntity<ReviewData>>
    {
    }
}