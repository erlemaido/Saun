using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.Statuses;
using Domain.Abstractions;

namespace Domain.Shop.Statuses
{
    [TestClass]
    public class StatusTests : SealedClassTests<Status, NamedEntity<StatusData>>
    {
    }
}
