using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.Cities;
using Data.Shop.Units;
using Domain.Abstractions;
using Domain.Shop.Cities;
using Domain.Shop.Units;
using Facade.Shop.Cities;
using Facade.Shop.Units;
using Infra.Shop.Cities;
using Sauna.Pages.Shop.Cities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Cities
{
    [TestClass]
    public class CitiesPageTests : SealedViewPageTests<CitiesPage,
            ICitiesRepository, City, CityView, CityData>
    {

        private CitiesRepository _cities;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(CityView item)
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

        protected override City CreateObj(CityData d)
        {
            throw new System.NotImplementedException();
        }
    }

}
