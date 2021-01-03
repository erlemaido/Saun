using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.People;
using Domain.Abstractions;

namespace Domain.Shop.People
{
    [TestClass]
    public class PersonTests : SealedClassTests<Person, UniqueEntity<PersonData>>
    {
    }
}