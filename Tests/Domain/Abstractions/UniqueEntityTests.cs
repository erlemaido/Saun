﻿using Aids.Reflection;
using Data.Shop.Products;
using Domain.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Abstractions
{

    [TestClass]
    public class UniqueEntityTests : AbstractClassTests<UniqueEntity<ProductData>, object>
    {

        private class TestClass : UniqueEntity<ProductData>
        {

            public TestClass(ProductData d = null) : base(d) { }

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass(GetRandom.Object<ProductData>());
        }

        [TestMethod] public void IdTest() => IsReadOnlyProperty(obj.Id);

        [TestMethod] public void DataTest() => IsReadOnlyProperty(obj.Data);

    }

}
