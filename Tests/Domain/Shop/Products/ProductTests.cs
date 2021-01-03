using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.Products;
using Domain.Abstractions;

namespace Domain.Shop.Products
{
    [TestClass]
    public class ProductTests : SealedClassTests<Product, UniqueEntity<ProductData>>
    {
    }
}