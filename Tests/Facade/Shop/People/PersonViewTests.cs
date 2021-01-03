using Facade.Abstractions;
using Facade.Shop.People;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.People
{
    [TestClass]
    public class PersonViewTests : SealedClassTests<PersonView, UniqueEntityView>
    {
        [TestMethod]
        public void FirstNameTest() => IsNullableProperty(() => obj.FirstName, x => obj.FirstName = x);

        [TestMethod]
        public void LastNameTest() => IsNullableProperty(() => obj.LastName, x => obj.LastName = x);

        [TestMethod]
        public void EmailTest() => IsNullableProperty(() => obj.Email, x => obj.Email = x);

 
    }
}
