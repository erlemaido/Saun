using Data.Abstractions;
using Data.Shop.People;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.People
{
    [TestClass]
    public class PersonDataTests : ClassTests<PersonData, UniqueEntityData>
    {
        [TestMethod]
        public void FirstNameTest()
        {
            IsNullableProperty(() => obj.FirstName, x => obj.FirstName = x);
        }

        [TestMethod]
        public void LastNameTest()
        {
            IsNullableProperty(() => obj.LastName, x => obj.LastName = x);
        }

        [TestMethod]
        public void EmailTest()
        {
            IsNullableProperty(() => obj.Email, x => obj.Email = x);
        }

    }
}
