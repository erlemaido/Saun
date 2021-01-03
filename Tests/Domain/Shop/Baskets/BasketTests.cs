using Data.Shop.Baskets;
using Domain.Abstractions;
using Domain.Shop.Baskets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Baskets
{
    [TestClass]
    public class BasketTests : SealedClassTests<Basket, NamedEntity<BasketData>>
    {
    }
}