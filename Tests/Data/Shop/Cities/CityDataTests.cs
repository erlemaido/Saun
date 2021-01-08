using Data.Abstractions;
using Data.Shop.Cities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.Cities
{
    [TestClass]
    public class CityDataTests : SealedClassTests<CityData, NamedEntityData>
    {
        [TestMethod]
        public void CountryIdTest()
        {
            IsNullableProperty(() => obj.CountryId, x => obj.CountryId = x);
        }

    }
}
