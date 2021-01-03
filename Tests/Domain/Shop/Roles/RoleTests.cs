using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Data.Shop.Roles;
using Domain.Abstractions;

namespace Domain.Shop.Roles
{
    [TestClass]
    public class RoleTests : SealedClassTests<Role, DefinedEntity<RoleData>>
    {
    }
}