using Facade.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Facade.Abstractions
{

    [TestClass]
    public class UniqueEntityViewTests : AbstractClassTests<UniqueEntityView, object>
    {

        private class TestClass : UniqueEntityView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void IdTest()
        {
            IsNullableProperty(() => obj.Id, x => obj.Id = x);
        }

        [TestMethod]
        public void GetIdTest()
        {
            var actual = obj.GetId();
            var expected = $"{obj.Id}";
            Assert.AreEqual(expected, actual);
        }

    }

}
