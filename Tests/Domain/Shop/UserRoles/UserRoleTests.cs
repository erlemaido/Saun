using Data.Shop.UserRoles;
using Domain.Abstractions;
using Domain.Shop.UserRoles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.UserRoles
{
    [TestClass]
    public class UserRoleTests : SealedClassTests<UserRole, UniqueEntity<UserRoleData>>
    {
    }
}