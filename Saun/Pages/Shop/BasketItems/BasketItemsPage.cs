using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Baskets;
using Data.Shop.Products;
using Domain.Shop.BasketItems;
using Domain.Shop.Baskets;
using Domain.Shop.Products;
using Facade.Shop.BasketItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.BasketItems
{
   public sealed class BasketItemsPage : ViewPage<IBasketItemsRepository, BasketItem, BasketItemView, BasketItemData>
    {
        public BasketItemsPage(
            IBasketItemsRepository repository, 
            IBasketsRepository basketsRepository, 
            IProductsRepository productsRepository) : base(repository, PagesNames.BasketItems)
        {
            Baskets = NewItemsList<Basket, BasketData>(basketsRepository);
            Products = NewItemsList<Product, ProductData>(productsRepository);
        }

        public IEnumerable<SelectListItem> Baskets { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }

        protected internal override BasketItem ToObject(BasketItemView view) => BasketItemViewFactory.Create(view);
        
        protected internal override BasketItemView ToView(BasketItem obj) => BasketItemViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.BasketItems, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new BasketItemView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        public string GetBasketName(string itemBasketId) => GetItemName(Baskets, itemBasketId);

        public string GetProductName(string itemProductId) => GetItemName(Products, itemProductId);
        
        private bool IsBasket() => FixedFilter == GetMember.Name<BasketItemView>(x => x.BasketId);
        
        private bool IsProduct() => FixedFilter == GetMember.Name<BasketItemView>(x => x.ProductId);
        
        protected internal override string GetPageSubtitle()
        {
            if (IsBasket())
            {
                return $"{GetBasketName(FixedValue)}";
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