using Data.Shop.PaymentTypes;
using Data.Shop.PaymentTypes;
using Domain.Abstractions;
using Domain.Shop.PaymentTypes;
using Domain.Shop.PaymentTypes;
using Facade.Shop.PaymentTypes;
using Infra.Shop.PaymentTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.PaymentTypes;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.PaymentTypes
{
    [TestClass]
    public class PaymentTypesPageTests : SealedViewPageTests<PaymentTypesPage,
        IPaymentTypesRepository, PaymentType, PaymentTypeView, PaymentTypeData>
    {

        private PaymentTypesRepository _paymentTypes;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(PaymentTypeView item)
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

        protected override PaymentType CreateObj(PaymentTypeData d)
        {
            throw new System.NotImplementedException();
        }
    }

}
