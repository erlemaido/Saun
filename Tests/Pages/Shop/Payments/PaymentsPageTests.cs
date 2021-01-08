using Data.Shop.Payments;
using Domain.Abstractions;
using Domain.Shop.Payments;
using Facade.Shop.Payments;
using Infra.Shop.Payments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Payments;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Payments
{
    [TestClass]
    public class PaymentsPageTests : SealedViewPageTests<PaymentsPage,
            IPaymentsRepository, Payment, PaymentView, PaymentData>
    {

        private PaymentsRepository Payments;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(PaymentView item)
        {
            throw new System.NotImplementedException();
        }

        protected override string PageTitle()
        {
            throw new System.NotImplementedException();
        }

        protected override string PageUrl()
        {
            throw new System.NotImplementedException();
        }

        protected override Payment CreateObj(PaymentData d)
        {
            throw new System.NotImplementedException();
        }
    }

}
