using Data.Shop.Stock;
using Domain.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Stock
{
    [TestClass]
    public class StockTests : SealedClassTests<global::Domain.Shop.Stock.Stock, UniqueEntity<StockData>>
    {
    }
}