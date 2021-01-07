using Data.Abstractions;
using Data.Shop.Stocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.Stocks
{
    [TestClass]
    public class StockDataTests : SealedClassTests<StockData, UniqueEntityData>
    {
        [TestMethod]
        public void ProductIdTest()
        {
            IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);
        }
        [TestMethod]
        public void CommentTest()
        {
            IsNullableProperty(() => obj.Comment, x => obj.Comment = x);
        }
        [TestMethod]
        public void InStockTest()
        {
            IsProperty(() => obj.InStock, x => obj.InStock = x);
        }
        [TestMethod]
        public void LastUpdateTimeTest()
        {
            IsProperty(() => obj.LastUpdateTime, x => obj.LastUpdateTime = x);
        }

    }
}
