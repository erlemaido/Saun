using System;
using System.Collections.Generic;
using System.Text;
using Facade.DeliveryCountries;
using Facade.DeliveryStatuses;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.DeliveryStatuses
{
    public sealed class DeliveryStatusPage : ViewsPage<IDeliveryStatusesRepository, DeliveryStatus, DeliveryStatusView, DeliveryStatusData>
    {
        public DeliveryStatusPage(IDeliveryStatusesRepository deliveryStatusesRepository) : base(deliveryStatusesRepository, PagesNames.DeliveryStatus)
        {
        }
        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.DeliveryStatus, UriKind.Relative);

        protected internal override DeliveryStatus ToObject(DeliveryStatusView view) => DeliveryStatusViewFactory.Create(view);

        protected internal override DeliveryStatusView ToView(DeliveryStatus obj) => DeliveryStatusViewFactory.Create(obj);

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new DeliveryStatusView() { Id = Guid.NewGuid().ToString() };

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }

}
