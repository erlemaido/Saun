using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.Reviews;
using Domain.Shop.Reviews;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Reviews
{
    [TestClass]
    public class ReviewsRepositoryTests : RepositoryTests<ReviewsRepository, Review, ReviewData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Reviews;
            obj = new ReviewsRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Review, ReviewData>);
        }

        protected override string GetId(ReviewData d) => d.Id;

        protected override Review GetObject(ReviewData d) => new Review(d);

        protected override void SetId(ReviewData d, string id) => d.Id = id;
    }
}
