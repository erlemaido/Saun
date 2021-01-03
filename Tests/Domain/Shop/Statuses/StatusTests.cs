using Data.Shop.Statuses;
using Domain.Abstractions;
using Domain.Shop.Statuses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Statuses
{
    [TestClass]
    public class StatusTests : SealedClassTests<Status, NamedEntity<StatusData>>
    {
    }
}
