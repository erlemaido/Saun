using System;
using Data.Shop.Reviews;
using Domain.Shop.Reviews;
using Facade.Shop.Reviews;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Reviews
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
