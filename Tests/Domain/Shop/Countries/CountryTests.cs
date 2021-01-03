using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.Countries;
using Domain.Abstractions;

namespace Domain.Shop.Countries
{
    [TestClass]
    public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>>
    {
    }
}
