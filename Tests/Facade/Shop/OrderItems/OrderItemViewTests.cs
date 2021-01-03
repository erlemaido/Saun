using Facade.Abstractions;
using Facade.Shop.OrderItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.OrderItems
{
    [TestClass]
    public class OrderItemViewTests : SealedClassTests<OrderItemView, UniqueEntityView>
    {
        [TestMethod]
        public void OrderIdTest() => IsNullableProperty(() => obj.OrderId, x => obj.OrderId = x);

        [TestMethod]
        public void ProductIdTest() => IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);

        [TestMethod]
        public void QuantityTest() => IsProperty(() => obj.Quantity, x => obj.Quantity = x);
    }
}
