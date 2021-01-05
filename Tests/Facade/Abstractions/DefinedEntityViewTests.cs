using Facade.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Abstractions {

    [TestClass]
    public class DefinedEntityViewTests : AbstractClassTests<DefinedEntityView, NamedEntityView> {

        private class TestClass : DefinedEntityView { }

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
