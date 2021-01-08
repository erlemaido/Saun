using Data.Abstractions;
using Data.Shop.OrderItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.OrderItems
{
    [TestClass]
    public class OrderItemDataTests : SealedClassTests<OrderItemData, UniqueEntityData>
    {
        [TestMethod]
        public void OrderIdTest()
        {
            IsNullableProperty(() => obj.OrderId, x => obj.OrderId = x);
        }
        [TestMethod]
        public void ProductIdTest()
        {
            IsNullableProperty(() => obj.ProductId, x => obj.ProductId = x);
        }
        [TestMethod]
        public void QuantityTest()
        {
            IsProperty(() => obj.Quantity, x => obj.Quantity = x);
        }

    }
}