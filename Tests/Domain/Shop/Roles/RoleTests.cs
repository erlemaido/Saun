using Data.Shop.Roles;
using Domain.Abstractions;
using Domain.Shop.Roles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Shop.Roles
{
    [TestClass]
    public class RoleTests : SealedClassTests<Role, DefinedEntity<RoleData>>
    {
    }
}