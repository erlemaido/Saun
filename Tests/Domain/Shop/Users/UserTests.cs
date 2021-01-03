using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.Users;
using Domain.Abstractions;

namespace Domain.Shop.Users
{
    [TestClass]
    public class UserTests : SealedClassTests<User, UniqueEntity<UserData>>
    {
    }
}