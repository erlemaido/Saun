using Aids.Reflection;
using Data.Shop.People;
using Domain.Shop.People;
using Facade.Shop.People;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.People
{
    [TestClass]
    public class PersonViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(PersonViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<PersonView>();
            var data = PersonViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<PersonData>();
            var view = PersonViewFactory.Create(new Person(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
