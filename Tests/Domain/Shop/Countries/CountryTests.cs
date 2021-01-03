using Data.Shop.Countries;
using Domain.Abstractions;
using Domain.Shop.Countries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Countries
{
    [TestClass]
    public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>>
    {
    }
}
