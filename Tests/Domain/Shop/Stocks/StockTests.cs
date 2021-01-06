using Data.Shop.Stocks;
using Domain.Abstractions;
using Domain.Shop.Stocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Stocks
{
    [TestClass]
    public class StockTests : SealedClassTests<Stock, UniqueEntity<StockData>>
    {
    }
}