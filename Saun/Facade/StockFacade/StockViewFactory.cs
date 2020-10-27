using System;
using System.Collections.Generic;
using System.Text;
using Aids.Methods;
using Saun.Data.Stock;
using Saun.Domain.StockDomain;

namespace Saun.Facade.StockFacade
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
