using Data.Shop.Statuses;
using Domain.Abstractions;
using Domain.Shop.Statuses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Pages.Shop.Statuses
{
    [TestClass]
    public class StatusesPageTests : SealedClassTests<Status, NamedEntity<StatusData>>
    {
    }
}
