using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.Units;
using Domain.Abstractions;

namespace Domain.Shop.Units
{
    [TestClass]
    public class UnitTests : SealedClassTests<Unit, NamedEntity<UnitData>>
    {
    }
}