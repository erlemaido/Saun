using Data.Shop.Stock;
using Domain.Abstractions;
using Domain.Shop.Stock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Stocks
{
    [TestClass]
    public class StockTests : SealedClassTests<Stock, UniqueEntity<StockData>>
    {
    }
}