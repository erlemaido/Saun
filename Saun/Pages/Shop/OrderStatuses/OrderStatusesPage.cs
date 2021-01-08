using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.Orders;
using Data.Shop.OrderStatuses;
using Data.Shop.Statuses;
using Domain.Shop.Orders;
using Domain.Shop.OrderStatuses;
using Domain.Shop.Statuses;
using Facade.Shop.OrderStatuses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.OrderStatuses
{
    public sealed class OrderStatusesPage : ViewPage<IOrderStatusesRepository, OrderStatus, OrderStatusView, OrderStatusData>
    {
        public OrderStatusesPage(
            IOrderStatusesRepository repository,
            IOrdersRepository ordersRepository,
            IStatusesRepository statusesRepository) : base(repository, PagesNames.OrderStatuses)
        {
            Orders = NewItemsList<Order, OrderData>(ordersRepository);
            Statuses = NewItemsList<Status, StatusData>(statusesRepository);
        }

        public IEnumerable<SelectListItem> Orders { get; set; }
        public IEnumerable<SelectListItem> Statuses { get; set; }

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

        public string GetOrderName(string itemOrderId) => GetItemName(Orders, itemOrderId);

        public string GetStatusName(string itemStatusId) => GetItemName(Statuses, itemStatusId);
        
        private bool IsOrder() => FixedFilter == GetMember.Name<OrderStatusView>(x => x.OrderId);
        
        private bool IsStatus() => FixedFilter == GetMember.Name<OrderStatusView>(x => x.StatusId);

        protected internal override string GetPageSubtitle()
        {
            if (IsOrder())
            {
                return $"{GetOrderName(FixedValue)}";
            }
            else if (IsStatus())
            {
                return $"{GetStatusName(FixedValue)}";
            }
            else
            {
                return "Määramata alalehe pealkiri";
            }
        }
    }
}