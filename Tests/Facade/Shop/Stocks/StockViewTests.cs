using Facade.Abstractions;
using Facade.Shop.Stocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Stocks
{
    [TestClass]
    public class StockViewTests : SealedClassTests<StockView, UniqueEntityView>
    {
        [TestMethod]
        public void ProductIdTest() => IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);

        [TestMethod]
        public void ProductTest() => IsNullableProperty(() => obj.Product, x => obj.Product = x);

        [TestMethod]
        public void InStockTest() => IsProperty(() => obj.InStock, x => obj.InStock = x);

        [TestMethod]
        public void LastUpdateTimeTest() => IsProperty(() => obj.LastUpdateTime, x => obj.LastUpdateTime = x);

        [TestMethod]
        public void CommentTest() => IsNullableProperty(() => obj.Comment, x => obj.Comment = x);

    }
}