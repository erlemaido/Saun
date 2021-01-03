using System;
using System.Collections.Generic;
using System.Text;
using Data.Abstractions;
using Data.Shop.Roles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.Roles
{
    [TestClass]
    public class RoleDataTests : SealedClassTests<RoleData, DefinedEntityData>
    {
        [TestMethod]
        public void ValidFromTest()
        {
            IsProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);
        }

        [TestMethod]
        public void ValidToTest()
        {
            IsProperty(() => obj.ValidTo, x => obj.ValidTo = x);
        }

    }
}
