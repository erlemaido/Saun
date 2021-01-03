using Data.Shop.Users;
using Domain.Abstractions;
using Domain.Shop.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Users
{
    [TestClass]
    public class UserTests : SealedClassTests<User, UniqueEntity<UserData>>
    {
    }
}