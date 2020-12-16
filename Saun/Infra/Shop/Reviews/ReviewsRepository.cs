using Data.Shop.Reviews;
using Domain.Shop.Reviews;
using Infra.Abstractions;

namespace Infra.Shop.Reviews
{
    public sealed class ReviewsRepository : UniqueEntityRepository<Review, ReviewData>, IReviewsRepository
    {
        protected internal override Review ToDomainObject(ReviewData data) => new Review(data);

        public ReviewsRepository(SaunaDbContext context) : base(context, context.Reviews)
        {
        }
    }
}