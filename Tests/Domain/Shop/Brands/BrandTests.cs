using Data.Shop.Brands;
using Domain.Abstractions;
using Domain.Shop.Brands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Brands
{
    [TestClass]
    public class BrandTests : SealedClassTests<Brand, DefinedEntity<BrandData>>
    {
    }
}