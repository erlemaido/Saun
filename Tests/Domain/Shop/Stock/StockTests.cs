using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.Stock;
using Domain.Abstractions;

namespace Domain.Shop.Stock
{
    [TestClass]
    public class StockTests : SealedClassTests<Stock, UniqueEntity<StockData>>
    {
    }
}