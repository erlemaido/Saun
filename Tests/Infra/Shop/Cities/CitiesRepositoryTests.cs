using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.Cities;
using Domain.Shop.Cities;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Cities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Cities
{
    [TestClass]
    public class CitiesRepositoryTests : RepositoryTests<CitiesRepository, City, CityData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Cities;
            obj = new CitiesRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<City, CityData>);
        }

        protected override string GetId(CityData d) => d.Id;

        protected override City GetObject(CityData d) => new City(d);

        protected override void SetId(CityData d, string id) => d.Id = id;
    }
}
