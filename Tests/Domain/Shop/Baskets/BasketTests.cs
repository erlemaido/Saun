using Data.Shop.Baskets;
using Domain.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Domain.Shop.Baskets
{
    [TestClass]
    public class BasketTests : SealedClassTests<Basket, NamedEntity<BasketData>>
    {
    }
}