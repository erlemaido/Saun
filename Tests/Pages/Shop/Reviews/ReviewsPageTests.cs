using Data.Shop.Reviews;
using Domain.Abstractions;
using Domain.Shop.Reviews;
using Facade.Shop.Reviews;
using Infra.Shop.Reviews;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Reviews;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Reviews
{
    [TestClass]
    public class ReviewsPageTests : SealedViewPageTests<ReviewsPage,
            IReviewsRepository, Review, ReviewView, ReviewData>
    {

        private ReviewsRepository Reviews;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(ReviewView item)
        {
            throw new System.NotImplementedException();
        }

        protected override string PageTitle()
        {
            throw new System.NotImplementedException();
        }

        protected override string PageUrl()
        {
            throw new System.NotImplementedException();
        }

        protected override Review CreateObj(ReviewData d)
        {
            throw new System.NotImplementedException();
        }
    }

}