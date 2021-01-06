using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.DeliveryTypes;
using Domain.Shop.DeliveryTypes;
using Infra;
using Infra.Abstractions;
using Infra.Shop.DeliveryTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.DeliveryTypes
{
    [TestClass]
    public class DeliveryTypesRepositoryTests : RepositoryTests<DeliveryTypesRepository, DeliveryType, DeliveryTypeData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).DeliveryTypes;
            obj = new DeliveryTypesRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<DeliveryType, DeliveryTypeData>);
        }

        protected override string GetId(DeliveryTypeData d) => d.Id;

        protected override DeliveryType GetObject(DeliveryTypeData d) => new DeliveryType(d);

        protected override void SetId(DeliveryTypeData d, string id) => d.Id = id;
    }
}
