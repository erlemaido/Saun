using Aids.Methods;
using Data.Reviews;
using Domain.Reviews;

namespace Facade.Reviews
{
    public static class ReviewViewFactory
    {
        public static Review Create(ReviewView view)
        {
            var ReviewData = new ReviewData();
            Copy.Members(view, ReviewData);
            
            return new Review(ReviewData);
        }
        public static ReviewView Create(Review Review)
        {
            var view = new ReviewView();
            Copy.Members(Review.Data, view);

            return view;
        }
    }
}
