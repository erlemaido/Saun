using Data.Shop.Cities;
using Domain.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Domain.Shop.Cities
{
    [TestClass]
    public class CityTests : SealedClassTests<City, NamedEntity<CityData>>
    {
    }
}
