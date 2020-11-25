using System;
using Data.Stocks;
using Domain.Stocks;
using Facade.Stocks;

namespace Pages.Stocks
{
    public class StocksPage : ViewPage<IStocksRepository, Stock, StockView, StockData>
    {
        public StocksPage(IStocksRepository repository) : base(repository, "ladu")
        {
        }

        protected internal override Stock ToObject(StockView view) => StockViewFactory.Create(view);

        protected internal override StockView ToView(Stock obj) => StockViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri("/Stocks", UriKind.Relative);
    }
}

