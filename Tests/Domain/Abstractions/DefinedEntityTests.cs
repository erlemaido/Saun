using Aids.Reflection;
using Data.Shop.Products;
using Domain.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Abstractions {

    [TestClass]
    public class DefinedEntityTests : AbstractClassTests<DefinedEntity<ProductData>, NamedEntity<ProductData>> {

        private class TestClass : DefinedEntity<ProductData> {

            public TestClass(ProductData d = null) : base(d) { }

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass(GetRandom.Object<ProductData>());
        }

        [TestMethod] public void DescriptionTest() => IsReadOnlyProperty(obj.Description);

    }

}
