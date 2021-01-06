using System;
using System.Collections.Generic;
using Data.Shop.Products;
using Data.Shop.Stocks;
using Domain.Shop.Products;
using Domain.Shop.Stocks;
using Facade.Shop.Stocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Stocks
{
    public class StockPage : ViewPage<IStockRepository, Stock, StockView, StockData>
    {
        public IEnumerable<SelectListItem> Products { get; }

        public StockPage(IStockRepository repository, IProductsRepository productsRepository) : base(repository, PagesNames.Stock)
        {
            Products = NewItemsList<Product, ProductData>(productsRepository);
        }
        public string GetProductName(string id) => GetItemName(Products, id);
        
        protected internal override Stock ToObject(StockView view) => StockViewFactory.Create(view);

        protected internal override StockView ToView(Stock obj) => StockViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Stock, UriKind.Relative);
        
        protected internal override string GetPageSubtitle() => $"{GetProductName(FixedValue)}";
        
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

