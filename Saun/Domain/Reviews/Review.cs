using Data.Reviews;
using Domain.Abstractions;

namespace Domain.Reviews
{
    public sealed class Review : DefinedEntity<ReviewData>
    {
        public Review() : this(null)
        {
            
        }

        public Review(ReviewData data) : base(data)
        {
            
        }
    }
}