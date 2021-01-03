using Data.Shop.People;
using Domain.Abstractions;
using Domain.Shop.People;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.People
{
    [TestClass]
    public class PersonTests : SealedClassTests<Person, UniqueEntity<PersonData>>
    {
    }
}