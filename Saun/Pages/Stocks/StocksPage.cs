// using System;
// using System.Collections.Generic;
// using System.Text;
// using Data.Stocks;
// using Domain.Stocks;
// using Facade.Stocks;
//
// namespace Pages.Stocks
// {
//     public class StocksPage : CommonPage<IStocksRepository, Stock, StockView, StockData>
//     {
//         protected internal StocksPage(IStocksRepository StocksRepository) : base(
//             StocksRepository)
//     {
//         PageTitle = "Laoseis";
//     }
//
//     public override Guid ItemId => Item.Id;
//
//     protected internal override string GetPageUrl() => "/Saun/Stocks";
//
//     protected internal override Stock ToObject(StockView view)
//     {
//         return StockViewFactory.Create(view);
//     }
//
//     protected internal override StockView ToView(Stock obj)
//     {
//         return StockViewFactory.Create(obj);
//     }
// }
// }
