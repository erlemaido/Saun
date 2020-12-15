using Data.Reviews;
using Domain.Reviews;
using Infra.Abstractions;

namespace Infra.Reviews
{
    public sealed class ReviewsRepository : UniqueEntityRepository<Review, ReviewData>, IReviewsRepository
    {
        protected internal override Review ToDomainObject(ReviewData data) => new Review(data);

        public ReviewsRepository(SaunaDbContext context) : base(context, context.Reviews)
        {
        }
    }
}