using Facade.Abstractions;
using Facade.Shop.Roles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Roles
{
    [TestClass]
    public class RoleViewTests : SealedClassTests<RoleView, DefinedEntityView>
    {
        [TestMethod]
        public void ValidFromTest() => IsProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);

        [TestMethod]
        public void ValidToTest() => IsProperty(() => obj.ValidTo, x => obj.ValidTo = x);
    }
}
