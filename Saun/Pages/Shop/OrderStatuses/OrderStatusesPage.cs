using System;
using Data.Shop.OrderStatuses;
using Domain.Shop.OrderStatuses;
using Facade.Shop.OrderStatuses;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.OrderStatuses
{
    public class OrderStatusesPage : ViewPage<IOrderStatusesRepository, OrderStatus, OrderStatusView, OrderStatusData>
    {
        public OrderStatusesPage(IOrderStatusesRepository repository) : base(repository, PagesNames.OrderStatuses)
        {
        }

        protected internal override OrderStatus ToObject(OrderStatusView view) => OrderStatusViewFactory.Create(view);
        
        protected internal override OrderStatusView ToView(OrderStatus obj) => OrderStatusViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.OrderStatuses, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new OrderStatusView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}