using System;
using System.Collections.Generic;
using Data.Products;
using Data.Stocks;
using Domain.Products;
using Domain.Stocks;
using Facade.Stocks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pages.Stocks
{
    public class StocksPage : ViewPage<IStocksRepository, Stock, StockView, StockData>
    {
        public IEnumerable<SelectListItem> Products { get; }

        public StocksPage(IStocksRepository repository, IProductsRepository productsRepository) : base(repository, "Ladu")
        {
            Products = NewItemsList<Product, ProductData>(productsRepository);
        }
        public string ProductName(Guid id) => ItemName(Products, id);

        protected internal override Stock ToObject(StockView view) => StockViewFactory.Create(view);

        protected internal override StockView ToView(Stock obj) => StockViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri("/Stocks", UriKind.Relative);
    }
}

