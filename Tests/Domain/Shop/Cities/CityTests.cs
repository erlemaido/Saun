using Data.Shop.Cities;
using Domain.Abstractions;
using Domain.Shop.Cities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Cities
{
    [TestClass]
    public class CityTests : SealedClassTests<City, NamedEntity<CityData>>
    {
    }
}
