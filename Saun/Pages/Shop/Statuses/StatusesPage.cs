using System;
using Data.Shop.Statuses;
using Domain.Shop.Statuses;
using Facade.Shop.Statuses;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Statuses
{
    public sealed class StatusesPage : ViewsPage<IStatusesRepository, Status, StatusView, StatusData>
    {
        public StatusesPage(IStatusesRepository statusesRepository) : base(statusesRepository, PagesNames.Statuses)
        {
        }
        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Statuses, UriKind.Relative);

        protected internal override Status ToObject(StatusView view) => StatusViewFactory.Create(view);

        protected internal override StatusView ToView(Status obj) => StatusViewFactory.Create(obj);

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new StatusView() { Id = Guid.NewGuid().ToString() };

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }

}
