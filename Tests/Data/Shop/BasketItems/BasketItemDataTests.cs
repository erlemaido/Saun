﻿using Data.Abstractions;
using Data.Shop.BasketItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.BasketItems
{
    [TestClass]
    public class BasketItemDataTests : SealedClassTests<BasketItemData, UniqueEntityData>
    {

        [TestMethod]
        public void IdTest()
        {
            IsNullableProperty(() => obj.Id, x => obj.Id = x);
        }

        [TestMethod]
        public void ProductIdTest()
        {
            IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);
        }

        [TestMethod]
        public void QuantityTest()
        {
            IsProperty(() => obj.Quantity, x => obj.Quantity = x);
        }
    }
}

