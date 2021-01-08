using System;
using Data.Shop.PaymentTypes;
using Domain.Shop.PaymentTypes;
using Infra;
using Infra.Abstractions;
using Infra.Shop.PaymentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.PaymentTypes
{
    [TestClass]
    public class PaymentTypesRepositoryTests : RepositoryTests<PaymentTypesRepository, PaymentType, PaymentTypeData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).PaymentTypes;
            obj = new PaymentTypesRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<PaymentType, PaymentTypeData>);
        }

        protected override string GetId(PaymentTypeData d) => d.Id;

        protected override PaymentType GetObject(PaymentTypeData d) => new PaymentType(d);

        protected override void SetId(PaymentTypeData d, string id) => d.Id = id;
    }
}
