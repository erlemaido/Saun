using Aids.Methods;
using Data.Shop.Reviews;
using Domain.Shop.Reviews;

namespace Facade.Shop.Reviews
{
    public static class ReviewViewFactory
    {
        public static Review Create(ReviewView view)
        {
            var reviewData = new ReviewData();
            Copy.Members(view, reviewData);
            
            return new Review(reviewData);
        }
        public static ReviewView Create(Review review)
        {
            var view = new ReviewView();
            Copy.Members(review.Data, view);

            return view;
        }
    }
}
