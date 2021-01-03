using Aids.Reflection;
using Data.Shop.Products;
using Domain.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Abstractions
{

    [TestClass]
    public class NamedEntityTests : AbstractClassTests<NamedEntity<ProductData>, UniqueEntity<ProductData>>
    {

        private class testClass : NamedEntity<ProductData>
        {

            public testClass(ProductData d = null) : base(d) { }

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass(GetRandom.Object<ProductData>());
        }

        [TestMethod] public void NameTest() => IsReadOnlyProperty(obj.Name);
    }
}