using System;
using Data.Shop.People;
using Domain.Shop.People;
using Infra;
using Infra.Abstractions;
using Infra.Shop.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.People
{
    [TestClass]
    public class PeopleRepositoryTests : RepositoryTests<PeopleRepository, Person, PersonData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).People;
            obj = new PeopleRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Person, PersonData>);
        }

        protected override string GetId(PersonData d) => d.Id;

        protected override Person GetObject(PersonData d) => new Person(d);

        protected override void SetId(PersonData d, string id) => d.Id = id;
    }
}
