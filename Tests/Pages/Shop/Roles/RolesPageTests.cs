using System.Collections.Generic;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.Reviews;
using Data.Shop.Roles;
using Domain.Shop.Reviews;
using Domain.Shop.Roles;
using Facade.Shop.Roles;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Roles;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Roles
{
    [TestClass]
    public class RolesPageTests : SealedViewPageTests<RolesPage,
            IRolesRepository, Role, RoleView, RoleData>
    {
        internal class RolesTestRepository : UniqueRepository<Role, RoleData>, IRolesRepository
        {
            protected override string GetId(RoleData d) => d.Id;

            public Task AddAll(List<Role> obj)
            {
                throw new System.NotImplementedException();
            }
        }


        private RolesTestRepository _rolesTest;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _rolesTest = new RolesTestRepository();
            obj = new RolesPage(_rolesTest);
        }
        protected override string GetId(RoleView item) => item.Id;

        protected override string PageTitle() => PagesNames.Roles;

        protected override string PageUrl() => PagesUrls.Roles;
        protected override Role CreateObj(RoleData d) => new Role(d);



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
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

       
    }

}