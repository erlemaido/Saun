using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.UserRoles;
using Domain.Shop.UserRoles;
using Infra;
using Infra.Abstractions;
using Infra.Shop.UserRoles;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.UserRoles
{
    [TestClass]
    public class UserRolesRepositoryTests : RepositoryTests<UserRolesRepository, UserRole, UserRoleData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).UserRoles;
            obj = new UserRolesRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<UserRole, UserRoleData>);
        }

        protected override string GetId(UserRoleData d) => d.Id;

        protected override UserRole GetObject(UserRoleData d) => new UserRole(d);

        protected override void SetId(UserRoleData d, string id) => d.Id = id;
    }
}
