using System;
using Data.Reviews;
using Domain.Reviews;
using Facade.Reviews;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Reviews
{
    public class ReviewsPage : ViewPage<IReviewsRepository, Review, ReviewView, ReviewData>
    {
        public ReviewsPage(IReviewsRepository repository) : base(repository, PagesNames.Reviews)
        {
        }

        protected internal override Review ToObject(ReviewView view) => ReviewViewFactory.Create(view);

        protected internal override ReviewView ToView(Review obj) => ReviewViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Reviews, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new ReviewView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}
