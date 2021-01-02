using Data.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Domain.Abstractions;

namespace Tests.Data.Abstractions {

    [TestClass] public class NamedEntityDataTests : AbstractClassTests<NamedEntityData, UniqueEntityData> {

        private class TestClass : NamedEntityData { }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod] public void NameTest()
            => IsNullableProperty(() => obj.Name, x => obj.Name = x);


    }

}