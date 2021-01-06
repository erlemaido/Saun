using Facade.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Abstractions { 

    [TestClass]
    public class NamedEntityViewTests : AbstractClassTests<NamedEntityView, UniqueEntityView>
    {

        private class TestClass : NamedEntityView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void NameTest()
        {
            IsNullableProperty(() => obj.Name, x => obj.Name = x);
        }
    }
}