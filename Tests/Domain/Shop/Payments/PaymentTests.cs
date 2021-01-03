using Data.Shop.Payments;
using Domain.Abstractions;
using Domain.Shop.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Payments
{
    [TestClass]
    public class PaymentTests : SealedClassTests<Payment, UniqueEntity<PaymentData>>
    {
    }
}
