using Data.Shop.Products;
using Domain.Abstractions;
using Domain.Shop.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Products
{
    [TestClass]
    public class ProductTests : SealedClassTests<Product, UniqueEntity<ProductData>>
    {
    }
}