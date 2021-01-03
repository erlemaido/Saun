using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.ProductTypes;
using Domain.Abstractions;

namespace Domain.Shop.ProductTypes
{
    [TestClass]
    public class ProductTypeTests : SealedClassTests<ProductType, NamedEntity<ProductTypeData>>
    {
    }
}