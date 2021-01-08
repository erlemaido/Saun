using Data.Shop.Units;
using Domain.Abstractions;
using Domain.Shop.Units;
using Facade.Shop.Units;
using Infra.Shop.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Units;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Units
{
    [TestClass]
    public class UnitsPageTests : SealedViewPageTests<UnitsPage,
            IUnitsRepository, Unit, UnitView, UnitData>
    {

        private UnitsRepository _units;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(UnitView item)
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

        protected override Unit CreateObj(UnitData d)
        {
            throw new System.NotImplementedException();
        }
    }

}