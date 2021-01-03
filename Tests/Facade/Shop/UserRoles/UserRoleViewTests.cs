using Facade.Abstractions;
using Facade.Shop.UserRoles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.UserRoles
{
    [TestClass]
    public class UserRoleViewTests : SealedClassTests<UserRoleView, UniqueEntityView>
    {
        [TestMethod]
        public void UserIdTest() => IsNullableProperty(() => obj.UserId, x => obj.UserId = x);

        [TestMethod]
        public void RoleIdTest() => IsNullableProperty(() => obj.RoleId, x => obj.RoleId = x);

        [TestMethod]
        public void ValidFromTest() => IsProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);

        [TestMethod]
        public void ValidToTest() => IsProperty(() => obj.ValidTo, x => obj.ValidTo = x);

        [TestMethod]
        public void CommentTest() => IsNullableProperty(() => obj.Comment, x => obj.Comment = x);

    }
}
