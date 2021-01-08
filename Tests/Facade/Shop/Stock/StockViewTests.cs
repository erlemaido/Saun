using Facade.Abstractions;
using Facade.Shop.Stock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Stock
{
    [TestClass]
    public class StockViewTests : SealedClassTests<StockView, UniqueEntityView>
    {
        [TestMethod]
        public void ProductIdTest() => IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);

        [TestMethod]
        public void InStockTest() => IsProperty(() => obj.InStock, x => obj.InStock = x);

        [TestMethod]
        public void LastUpdateTimeTest() => IsProperty(() => obj.LastUpdateTime, x => obj.LastUpdateTime = x);

        [TestMethod]
        public void CommentTest() => IsNullableProperty(() => obj.Comment, x => obj.Comment = x);

    }
}