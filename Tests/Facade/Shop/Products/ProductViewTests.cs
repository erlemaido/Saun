using Facade.Abstractions;
using Facade.Shop.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Products
{
    [TestClass]
    public class ProductViewTests : SealedClassTests<ProductView, DefinedEntityView>
    {
        [TestMethod]
        public void BrandIdTest() => IsNullableProperty(() => obj.BrandId, x => obj.BrandId = x);

        [TestMethod]
        public void BrandTest() => IsNullableProperty(() => obj.Brand, x => obj.Brand = x);

        [TestMethod]
        public void ProductTypeIdTest() => IsNullableProperty(() => obj.ProductType, x => obj.ProductType = x);

        [TestMethod]
        public void ProductTypeTest() => IsNullableProperty(() => obj.ProductType, x => obj.ProductType = x);

        [TestMethod]
        public void UnitIdTest() => IsNullableProperty(() => obj.UnitId, x => obj.UnitId = x);

        [TestMethod]
        public void UnitTest() => IsNullableProperty(() => obj.Unit, x => obj.Unit = x);

        [TestMethod]
        public void PictureUrlTest() => IsNullableProperty(() => obj.PictureUrl, x => obj.PictureUrl = x);

        [TestMethod]
        public void PriceTest() => IsProperty(() => obj.Price, x => obj.Price = x);
    }
}
