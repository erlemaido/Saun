using Data.Shop.PaymentTypes;
using Domain.Abstractions;
using Domain.Shop.PaymentTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.PaymentTypes
{
    [TestClass]
    public class PaymentTypeTests : SealedClassTests<PaymentType, UniqueEntity<PaymentTypeData>>
    {
    }
}
