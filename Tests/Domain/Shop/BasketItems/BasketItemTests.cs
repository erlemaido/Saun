using Data.Shop.BasketItems;
using Domain.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Domain.Shop.BasketItems
{
    [TestClass] public class BasketItemTests : SealedClassTests<BasketItem, UniqueEntity<BasketItemData>>
    {
    }
}