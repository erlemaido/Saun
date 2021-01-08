using Data.Abstractions;
using Data.Shop.Baskets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.Baskets
{
    [TestClass]
    public class BasketDataTests : SealedClassTests<BasketData, NamedEntityData>
    {
        [TestMethod]
        public void PersonIdTest()
        {
            IsNullableProperty(() => obj.PersonId, x => obj.PersonId = x);
        }
        [TestMethod]
        public void TotalPriceTest()
        {
            IsProperty(() => obj.TotalPrice, x => obj.TotalPrice = x);
        }
    }
}
