using Data.Shop.ProductTypes;
using Domain.Abstractions;
using Domain.Shop.ProductTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.ProductTypes
{
    [TestClass]
    public class ProductTypeTests : SealedClassTests<ProductType, NamedEntity<ProductTypeData>>
    {
    }
}