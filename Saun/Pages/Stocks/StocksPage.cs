﻿using System;
using System.Collections.Generic;
using System.Text;
using Data.Stocks;
using Domain.Stocks;
using Facade.Stocks;

namespace Pages.Stocks
{
    public class StocksPage : ViewPage<IStocksRepository, Stock, StockView, StockData>
    {
        public StocksPage(IStocksRepository repository) : base(repository, "Ladu")
        {
        }

        protected internal override Stock ToObject(StockView view) => StockViewFactory.Create(view);

        protected internal override StockView ToView(Stock obj) => StockViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri("/Stocks", UriKind.Relative);
    }
}

