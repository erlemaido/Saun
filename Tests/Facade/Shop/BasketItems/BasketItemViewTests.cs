using Facade.Abstractions;
using Facade.Shop.BasketItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.BasketItems
{
    [TestClass]
    public class BasketItemViewTests : SealedClassTests<BasketItemView, UniqueEntityView>
    {
        [TestMethod]
        public void BasketIdTest() => IsNullableProperty(() => obj.BasketId, x => obj.BasketId = x);

        [TestMethod]
        public void ProductIdTest() => IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);

        [TestMethod]
        public void QuantityTest() => IsProperty(() => obj.Quantity, x => obj.Quantity = x);
    }
}
