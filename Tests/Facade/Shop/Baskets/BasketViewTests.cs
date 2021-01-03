using Facade.Abstractions;
using Facade.Shop.Baskets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Baskets
{
    [TestClass]
    public class BasketViewTests : SealedClassTests<BasketView, UniqueEntityView>
    {
        [TestMethod]
        public void NameTest() => IsNullableProperty(() => obj.Name, x => obj.Name = x);

        [TestMethod]
        public void PersonIdTest() => IsNullableProperty(() => obj.PersonId, x => obj.PersonId = x);

        [TestMethod]
        public void TotalPriceTest() => IsProperty(() => obj.TotalPrice, x => obj.TotalPrice = x);
    }
}
