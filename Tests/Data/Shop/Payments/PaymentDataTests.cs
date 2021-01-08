using Data.Abstractions;
using Data.Shop.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.Payments
{
    [TestClass]
    public class PaymentDataTests : SealedClassTests<PaymentData, UniqueEntityData>
    {
        [TestMethod]
        public void OrderIdTest()
        {
            IsNullableProperty(() => obj.OrderId, x => obj.OrderId = x);
        }

        [TestMethod]
        public void PersonIdTest()
        {
            IsNullableProperty(() => obj.PersonId, x => obj.PersonId = x);
        }
        [TestMethod]
        public void PaymentTypeIdTest()
        {
            IsNullableProperty(() => obj.PaymentTypeId, x => obj.PaymentTypeId = x);
        }

        [TestMethod]
        public void TimeTest()
        {
            IsProperty(() => obj.Time, x => obj.Time = x);
        }

    }
}
