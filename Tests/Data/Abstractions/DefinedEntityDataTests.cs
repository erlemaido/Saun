using Data.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Abstractions;

namespace Tests.Data.Abstractions
{
    [TestClass]
    public class DefinedEntityDataTests : AbstractClassTests<DefinedEntityData, NamedEntityData>
    {
        private class TestClass : DefinedEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void DescriptionTest()
        {
            IsNullableProperty(() => obj.Description, x => obj.Description = x);
        }
    }
}