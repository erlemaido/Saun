using Aids.Reflection;
using Data.Shop.DeliveryTypes;
using Domain.Shop.DeliveryTypes;
using Facade.Shop.DeliveryTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.DeliveryTypes
{
    [TestClass]
    public class DeliveryTypeViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(DeliveryTypeViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<DeliveryTypeView>();
            var data = DeliveryTypeViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<DeliveryTypeData>();
            var view = DeliveryTypeViewFactory.Create(new DeliveryType(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
