using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.Countries;
using Domain.Shop.Countries;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Countries
{
    [TestClass]
    public class CountriesRepositoryTests : RepositoryTests<CountriesRepository, Country, CountryData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Countries;
            obj = new CountriesRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Country, CountryData>);
        }

        protected override string GetId(CountryData d) => d.Id;

        protected override Country GetObject(CountryData d) => new Country(d);

        protected override void SetId(CountryData d, string id) => d.Id = id;
    }
}
