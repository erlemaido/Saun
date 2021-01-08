using Aids.Methods;
using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Baskets;
using Data.Shop.People;
using Data.Shop.Products;
using Data.Shop.Roles;
using Domain.Abstractions;
using Domain.Shop.People;
using Domain.Shop.Units;
using Domain.Shop.Roles;
using Facade.Shop.BasketItems;
using Facade.Shop.Roles;
using Infra.Shop.People;
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
        internal class rolesRepository : UniqueRepository<Role, RoleData>, IRolesRepository
        {
            protected override string GetId(RoleData d) => d.Id;

        }


        private rolesRepository Roles;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Roles = new rolesRepository();
            obj = new RolesPage(Roles);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Rollid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Roles", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<RoleView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<RoleView>();
            var view = obj.ToView(RoleViewFactory.Create(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetPersonNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void PeopleTest()
        {
            Assert.IsNull(null);
        }

        protected override Role CreateObj(RoleData d)
        {
            throw new System.NotImplementedException();
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

    }

}