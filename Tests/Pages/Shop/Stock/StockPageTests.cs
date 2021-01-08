using Data.Shop.Stock;
using Data.Shop.Stock;
using Domain.Abstractions;
using Domain.Shop.Stock;
using Facade.Shop.Stock;
using Infra.Shop.Stock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Stock;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Stock
{
    [TestClass]
    public class StockPageTests : SealedViewPageTests<StockPage,
        IStockRepository, global::Domain.Shop.Stock.Stock, StockView, StockData>
    {

        private StockRepository _stock;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(StockView item)
        {
            throw new System.NotImplementedException();
        }

        protected override string PageTitle()
        {
            throw new System.NotImplementedException();
        }

        protected override string PageUrl()
        {
            throw new System.NotImplementedException();
        }

        protected override global::Domain.Shop.Stock.Stock CreateObj(StockData d)
        {
            throw new System.NotImplementedException();
        }
    }

}