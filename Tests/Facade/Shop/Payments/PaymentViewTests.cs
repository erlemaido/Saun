using Facade.Abstractions;
using Facade.Shop.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Payments
{
    [TestClass]
    public class PaymentViewTests : SealedClassTests<PaymentView, UniqueEntityView>
    {
        [TestMethod]
        public void OrderIdTest() => IsNullableProperty(() => obj.PersonId, x => obj.PersonId = x);

        [TestMethod]
        public void PersonIdTest() => IsNullableProperty(() => obj.PersonId, x => obj.PersonId = x);

        [TestMethod]
        public void PaymentTypeIdTest() => IsNullableProperty(() => obj.PersonId, x => obj.PersonId = x);

        [TestMethod]
        public void TimeTest() => IsNullableProperty(() => obj.PersonId, x => obj.PersonId = x);
    }
}
