using Aids.Reflection;
using Data.Shop.Products;
using Domain.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Abstractions
{

    [TestClass]
    public class NamedEntityTests : AbstractClassTests<NamedEntity<ProductData>, UniqueEntity<ProductData>>
    {

        private class TestClass : NamedEntity<ProductData>
        {

            public TestClass(ProductData d = null) : base(d) { }

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass(GetRandom.Object<ProductData>());
        }

        [TestMethod] public void NameTest() => IsReadOnlyProperty(obj.Name);
    }
}