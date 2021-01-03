using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.DeliveryTypes;
using Domain.Abstractions;

namespace Domain.Shop.DeliveryTypes
{
    [TestClass]
    public class DeliveryTypeTests : SealedClassTests<DeliveryType, NamedEntity<DeliveryTypeData>>
    {
    }
}
