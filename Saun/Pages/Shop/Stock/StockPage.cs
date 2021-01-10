using System;
using System.Collections.Generic;
using Data.Shop.Products;
using Data.Shop.Stock;
using Domain.Shop.Products;
using Domain.Shop.Stock;
using Facade.Shop.Stock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Stock
{
    public sealed class StockPage : ViewPage<IStockRepository, Domain.Shop.Stock.Stock, StockView, StockData>
    {
        public IEnumerable<SelectListItem> Products { get; }

        public StockPage(IStockRepository repository, IProductsRepository productsRepository) : base(repository, PagesNames.Stock)
        {
            Products = NewItemsList<Product, ProductData>(productsRepository);
        }
        public string GetProductName(string id) => GetItemName(Products, id);
        
        protected internal override Domain.Shop.Stock.Stock ToObject(StockView view) => StockViewFactory.Create(view);

        protected internal override StockView ToView(Domain.Shop.Stock.Stock obj) => StockViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Stock, UriKind.Relative);

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new StockView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}

