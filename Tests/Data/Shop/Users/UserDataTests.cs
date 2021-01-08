using Data.Abstractions;
using Data.Shop.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.Users
{
    [TestClass]
    public class UserDataTests : ClassTests<UserData, UniqueEntityData>
    {
        [TestMethod]
        public void PersonIdTest()
        {
            IsNullableProperty(() => obj.PersonId, x => obj.PersonId = x);
        }

        [TestMethod]
        public void EmailConfirmedTest()
        {
            IsProperty(() => obj.EmailConfirmed, x => obj.EmailConfirmed = x);
        }
        [TestMethod]
        public void PasswordHashTest()
        {
            IsNullableProperty(() => obj.PasswordHash, x => obj.PasswordHash = x);
        }

        [TestMethod]
        public void ValidFromTest()
        {
            IsProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);
        }
        [TestMethod]
        public void ValidToTest()
        {
            IsProperty(() => obj.ValidTo, x => obj.ValidTo = x);
        }
        [TestMethod]
        public void CommentTest()
        {
            IsNullableProperty(() => obj.Comment, x => obj.Comment = x);
        }

    }
}
