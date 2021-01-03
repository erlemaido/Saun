using Facade.Abstractions;
using Facade.Shop.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Units
{
    [TestClass]
    public class UnitViewTests : SealedClassTests<UnitView, NamedEntityView>
    {
        [TestMethod]
        public void CodeTest() => IsNullableProperty(() => obj.Code, x => obj.Code = x);

    }
}
