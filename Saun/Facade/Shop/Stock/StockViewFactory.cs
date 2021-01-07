using Aids.Methods;
using Data.Shop.Stock;

namespace Facade.Shop.Stock
{
    public static class StockViewFactory
    {
        public static Domain.Shop.Stock.Stock Create(StockView view)
        {
            var stockData = new StockData();
            Copy.Members(view, stockData);
            
            return new Domain.Shop.Stock.Stock(stockData);
        }

        public static StockView Create(Domain.Shop.Stock.Stock stock)
        {
            var view = new StockView();
            Copy.Members(stock.Data, view);

            return view;
        }
    }
}
