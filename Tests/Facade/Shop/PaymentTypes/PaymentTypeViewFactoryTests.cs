using Aids.Reflection;
using Data.Shop.PaymentTypes;
using Domain.Shop.PaymentTypes;
using Facade.Shop.PaymentTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.PaymentTypes
{
    [TestClass]
    public class PaymentTypeViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(PaymentTypeViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<PaymentTypeView>();
            var data = PaymentTypeViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<PaymentTypeData>();
            var view = PaymentTypeViewFactory.Create(new PaymentType(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
