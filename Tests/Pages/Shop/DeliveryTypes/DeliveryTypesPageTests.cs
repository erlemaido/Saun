using Data.Shop.DeliveryTypes;
using Domain.Abstractions;
using Domain.Shop.DeliveryTypes;
using Facade.Shop.DeliveryTypes;
using Infra.Shop.DeliveryTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.DeliveryTypes;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.DeliveryTypes
{
    [TestClass]
    public class DeliveryTypesPageTests : SealedViewPageTests<DeliveryTypesPage,
            IDeliveryTypesRepository, DeliveryType, DeliveryTypeView, DeliveryTypeData>
    {

        private DeliveryTypesRepository DeliveryTypes;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(DeliveryTypeView item)
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

        protected override DeliveryType CreateObj(DeliveryTypeData d)
        {
            throw new System.NotImplementedException();
        }
    }

}
