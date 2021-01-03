using Data.Shop.Brands;
using Domain.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace Domain.Shop.Brands
{
    [TestClass]
    public class BrandTests : SealedClassTests<Brand, DefinedEntity<BrandData>>
    {
    }
}