using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.UserRoles;
using Domain.Abstractions;
using Domain.Shop.UserRoles;

namespace Domain.Shop.UserRoleTestss
{
    [TestClass]
    public class UserRoleTests : SealedClassTests<UserRole, UniqueEntity<UserRoleData>>
    {
    }
}