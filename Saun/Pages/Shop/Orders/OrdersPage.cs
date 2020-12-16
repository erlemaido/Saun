using System;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Facade.Shop.Orders;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Orders
{
    public class OrdersPage : ViewPage<IOrdersRepository, Order, OrderView, OrderData>
    {
        public OrdersPage(IOrdersRepository repository) : base(repository, PagesNames.Orders)
        {
        }

        protected internal override Order ToObject(OrderView view) => OrderViewFactory.Create(view);
        
        protected internal override OrderView ToView(Order obj) => OrderViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Orders, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new OrderView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
    
}
