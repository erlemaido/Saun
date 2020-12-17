using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.OrderItems;
using Data.Shop.Orders;
using Data.Shop.Products;
using Domain.Shop.OrderItems;
using Domain.Shop.Orders;
using Domain.Shop.Products;
using Facade.Shop.OrderItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.OrderItems
{
    public class OrderItemsPage : ViewPage<IOrderItemsRepository, OrderItem, OrderItemView, OrderItemData>
    {
        public OrderItemsPage(
            IOrderItemsRepository repository, 
            IOrdersRepository ordersRepository, 
            IProductsRepository productsRepository) : base(repository, PagesNames.OrderItems)
        {
            Orders = NewItemsList<Order, OrderData>(ordersRepository);
            Products = NewItemsList<Product, ProductData>(productsRepository);
        }

        public IEnumerable<SelectListItem> Orders { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }

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

        public string GetOrderName(string itemOrderId) => GetItemName(Orders, itemOrderId);

        public string GetProductName(string itemProductId) => GetItemName(Products, itemProductId);
        
        private bool IsOrder() => FixedFilter == GetMember.Name<OrderItemView>(x => x.OrderId);
        
        private bool IsProduct() => FixedFilter == GetMember.Name<OrderItemView>(x => x.ProductId);
        
        protected internal override string GetPageSubtitle()
        {
            if (IsOrder())
            {
                return $"{GetOrderName(FixedValue)}";
            }
            else if (IsProduct())
            {
                return $"{GetProductName(FixedValue)}";
            }
            else
            {
                return "Määramata alalehe pealkiri";
            }
        }
    }
}
