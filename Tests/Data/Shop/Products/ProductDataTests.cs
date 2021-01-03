using System;
using System.Collections.Generic;
using System.Text;
using Data.Abstractions;
using Data.Shop.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.Products
{
    [TestClass]
    public class ProductDataTests : SealedClassTests<ProductData, DefinedEntityData>
    {
        [TestMethod]
        public void BrandIdTest()
        {
            IsNullableProperty(() => obj.BrandId, x => obj.BrandId = x);
        }
        [TestMethod]
        public void ProductTypeIdTest()
        {
            IsNullableProperty(() => obj.ProductTypeId, x => obj.ProductTypeId= x);
        }
        [TestMethod]
        public void PictureUrlTest()
        {
            IsNullableProperty(() => obj.PictureUrl, x => obj.PictureUrl = x);
        }
        [TestMethod]
        public void UnitIdTest()
        {
            IsNullableProperty(() => obj.UnitId, x => obj.UnitId = x);
        }
        [TestMethod]
        public void PriceTest()
        {
            IsProperty(() => obj.Price, x => obj.Price = x);
        }
    }
}
