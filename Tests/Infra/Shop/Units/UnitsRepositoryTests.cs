using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.Units;
using Domain.Shop.Units;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Units
{
    [TestClass]
    public class UnitsRepositoryTests : RepositoryTests<UnitsRepository, Unit, UnitData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Units;
            obj = new UnitsRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Unit, UnitData>);
        }

        protected override string GetId(UnitData d) => d.Id;

        protected override Unit GetObject(UnitData d) => new Unit(d);

        protected override void SetId(UnitData d, string id) => d.Id = id;
    }
}
