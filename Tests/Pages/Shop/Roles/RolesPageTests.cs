using Data.Shop.Roles;
using Data.Shop.Roles;
using Domain.Abstractions;
using Domain.Shop.Roles;
using Domain.Shop.Roles;
using Facade.Shop.Roles;
using Infra.Shop.Roles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Roles;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Roles
{
    [TestClass]
    public class RolesPageTests : SealedViewPageTests<RolesPage,
        IRolesRepository, Role, RoleView, RoleData>
    {

        private RolesRepository Roles;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        protected override string GetId(RoleView item)
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

        protected override Role CreateObj(RoleData d)
        {
            throw new System.NotImplementedException();
        }
    }

}