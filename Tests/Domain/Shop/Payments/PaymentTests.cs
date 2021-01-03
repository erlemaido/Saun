using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.Payments;
using Domain.Abstractions;

namespace Domain.Shop.Payments
{
    [TestClass]
    public class PaymentTests : SealedClassTests<Payment, UniqueEntity<PaymentData>>
    {
    }
}
