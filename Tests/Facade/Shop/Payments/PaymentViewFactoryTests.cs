using Aids.Reflection;
using Data.Shop.Payments;
using Domain.Shop.Payments;
using Facade.Shop.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Payments
{
    [TestClass]
    public class PaymentViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(PaymentViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<PaymentView>();
            var data = PaymentViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<PaymentData>();
            var view = PaymentViewFactory.Create(new Payment(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
