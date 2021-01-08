using System;
using Data.Shop.Statuses;
using Domain.Shop.Statuses;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Statuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Statuses
{
    [TestClass]
    public class StatusesRepositoryTests : RepositoryTests<StatusesRepository, Status, StatusData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Statuses;
            obj = new StatusesRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Status, StatusData>);
        }

        protected override string GetId(StatusData d) => d.Id;

        protected override Status GetObject(StatusData d) => new Status(d);

        protected override void SetId(StatusData d, string id) => d.Id = id;
    }
}
