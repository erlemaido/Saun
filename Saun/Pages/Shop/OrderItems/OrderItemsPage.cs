using System;
using Data.Shop.OrderItems;
using Domain.Shop.OrderItems;
using Facade.Shop.OrderItems;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.OrderItems
{
    public class OrderItemsPage : ViewPage<IOrderItemsRepository, OrderItem, OrderItemView, OrderItemData>
    {
        public OrderItemsPage(IOrderItemsRepository repository) : base(repository, PagesNames.OrderItems)
        {
        }

        protected internal override OrderItem ToObject(OrderItemView view) => OrderItemViewFactory.Create(view);
        
        protected internal override OrderItemView ToView(OrderItem obj) => OrderItemViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.OrderItems, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new OrderItemView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}
