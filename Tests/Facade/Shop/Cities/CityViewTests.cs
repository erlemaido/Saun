using Facade.Abstractions;
using Facade.Shop.Cities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Cities
{
    [TestClass]
    public sealed class CityViewTests : SealedClassTests<CityView, NamedEntityView>
    {
        [TestMethod]
        public void CountryIdTest() => IsNullableProperty(() => obj.CountryId, x => obj.CountryId = x);

    }
}
