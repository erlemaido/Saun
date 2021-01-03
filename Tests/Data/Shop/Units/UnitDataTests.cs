using System;
using System.Collections.Generic;
using System.Text;
using Data.Abstractions;
using Data.Shop.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.Units
{
    [TestClass]
    public class UnitDataTests : ClassTests<UnitData, NamedEntityData>
    {
        [TestMethod]
        public void CodeTest()
        {
            IsNullableProperty(() => obj.Code, x => obj.Code = x);
        }
    }
}
