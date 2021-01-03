using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.PaymentTypes;
using Domain.Abstractions;

namespace Domain.Shop.PaymentTypes
{
    [TestClass]
    public class PaymentTypeTests : SealedClassTests<PaymentType, UniqueEntity<PaymentTypeData>>
    {
    }
}
