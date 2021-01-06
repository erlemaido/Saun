using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.Roles;
using Domain.Shop.Roles;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Roles
{
    [TestClass]
    public class RolesRepositoryTests : RepositoryTests<RolesRepository, Role, RoleData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Roles;
            obj = new RolesRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Role, RoleData>);
        }

        protected override string GetId(RoleData d) => d.Id;

        protected override Role GetObject(RoleData d) => new Role(d);

        protected override void SetId(RoleData d, string id) => d.Id = id;
    }
}
