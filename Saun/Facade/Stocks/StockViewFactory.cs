using Aids.Methods;
using Data.Stocks;
using Domain.Stocks;

namespace Facade.Stocks
{
    public static class StockViewFactory
    {
        public static Stock Create(StockView v)
        {
            var d = new StockData();
            Copy.Members(v, d);
            return new Stock(d);

        }

        public static StockView Create(Stock o)
        {
            var v = new StockView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
