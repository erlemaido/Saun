using Data.Shop.DeliveryTypes;
using Domain.Abstractions;
using Domain.Shop.DeliveryTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.DeliveryTypes
{
    [TestClass]
    public class DeliveryTypeTests : SealedClassTests<DeliveryType, NamedEntity<DeliveryTypeData>>
    {
    }
}
