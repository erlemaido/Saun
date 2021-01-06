using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.Users;
using Domain.Shop.Users;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Users
{
    [TestClass]
    public class UsersRepositoryTests : RepositoryTests<UsersRepository, User, UserData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Users;
            obj = new UsersRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<User, UserData>);
        }

        protected override string GetId(UserData d) => d.Id;

        protected override User GetObject(UserData d) => new User(d);

        protected override void SetId(UserData d, string id) => d.Id = id;
    }
}
