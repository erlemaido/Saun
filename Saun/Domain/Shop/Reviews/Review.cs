using Data.Shop.Reviews;
using Domain.Abstractions;

namespace Domain.Shop.Reviews
{
    public sealed class Review : UniqueEntity<ReviewData>
    {
        public Review() : this(null)
        {
            
        }

        public Review(ReviewData data) : base(data)
        {
            
        }
    }
}