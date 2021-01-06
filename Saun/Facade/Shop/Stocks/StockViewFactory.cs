using Aids.Methods;
using Data.Shop.Stocks;
using Domain.Shop.Stocks;

namespace Facade.Shop.Stocks
{
    public static class StockViewFactory
    {
        public static Stock Create(StockView view)
        {
            var stockData = new StockData();
            Copy.Members(view, stockData);
            
            return new Stock(stockData);
        }

        public static StockView Create(Stock stock)
        {
            var view = new StockView();
            Copy.Members(stock.Data, view);

            return view;
        }
    }
}
