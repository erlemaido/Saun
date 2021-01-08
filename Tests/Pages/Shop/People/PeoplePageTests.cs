using Data.Shop.People;
using Domain.Abstractions;
using Domain.Shop.People;
using Facade.Shop.People;
using Infra.Shop.People;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.People;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.People
{
    [TestClass]
    public class PeoplePageTests : SealedViewPageTests<PeoplePage,
            IPeopleRepository, Person, PersonView, PersonData>
    {

        private PeopleRepository People;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(PersonView item)
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

        protected override Person CreateObj(PersonData d)
        {
            throw new System.NotImplementedException();
        }
    }

}