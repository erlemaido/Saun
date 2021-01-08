using System;
using Data.Shop.Payments;
using Domain.Shop.Payments;
using Infra;
using Infra.Abstractions;
using Infra.Shop.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Infra.Abstractions;

namespace Tests.Infra.Shop.Payments
{
    [TestClass]
    public class PaymentsRepositoryTests : RepositoryTests<PaymentsRepository, Payment, PaymentData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SaunaDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new SaunaDbContext(options);
            dbSet = ((SaunaDbContext)db).Payments;
            obj = new PaymentsRepository((SaunaDbContext)db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Payment, PaymentData>);
        }

        protected override string GetId(PaymentData d) => d.Id;

        protected override Payment GetObject(PaymentData d) => new Payment(d);

        protected override void SetId(PaymentData d, string id) => d.Id = id;
    }
}
