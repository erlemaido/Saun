﻿using System;
using System.Collections.Generic;
using System.Text;
using Data.Abstractions;
using Data.Shop.BasketItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.BasketItems
{
    [TestClass]
    public class BasketItemsDataTests : SealedClassTests<BasketItemData, UniqueEntityData>
    {
        [TestMethod]
        public void BasketIdTest()
        {
            IsNullableProperty(() => obj.BasketId, x => obj.BasketId = x);
        }

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

