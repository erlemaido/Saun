using Aids.Reflection;
using Data.Shop.Stocks;
using Facade.Shop.Stocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Stocks
{
    [TestClass]
    public class StockViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(StockViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<StockView>();
            var data = StockViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<StockData>();
            var view = StockViewFactory.Create(new global::Domain.Shop.Stocks.Stock(data)); //??
            TestArePropertyValuesEqual(view, data);
        }
    }
}
