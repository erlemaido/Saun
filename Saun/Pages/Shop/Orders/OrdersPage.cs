using System;
using System.Collections.Generic;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Facade.Shop.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Orders
{
    public class OrdersPage : ViewPage<IOrdersRepository, Order, OrderView, OrderData>
    {
        public OrdersPage(IOrdersRepository repository) : base(repository, PagesNames.Orders)
        {
        }

        public IEnumerable<SelectListItem> People { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<SelectListItem> DeliveryTypes { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }

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

        public string GetPersonName(string itemPersonId)
        {
            throw new NotImplementedException();
        }

        public string GetUserName(string itemUserId)
        {
            throw new NotImplementedException();
        }

        public string GetDeliveryTypeName(string itemDeliveryTypeId)
        {
            throw new NotImplementedException();
        }

        public string GetCountryName(string itemCountryId)
        {
            throw new NotImplementedException();
        }

        public string GetCityName(string itemCityId)
        {
            throw new NotImplementedException();
        }
    }
    
}
