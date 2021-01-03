using Data.Shop.BasketItems;
using Domain.Abstractions;
using Domain.Shop.BasketItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.BasketItems
{
    [TestClass] public class BasketItemTests : SealedClassTests<BasketItem, UniqueEntity<BasketItemData>>
    {
    }
}