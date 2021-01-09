using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Units;
using Domain.Shop.BasketItems;
using Domain.Shop.Units;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Units;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Units
{
    [TestClass]
    public class UnitsPageTests : SealedViewPageTests<UnitsPage,
            IUnitsRepository, Unit, UnitView, UnitData>
    {
        internal class UnitsTestRepository : UniqueRepository<Unit, UnitData>, IUnitsRepository
        {
            protected override string GetId(UnitData d) => d.Id;

        }

        private UnitsTestRepository _unitsTest;
        protected override string GetId(UnitView item) => item.Id;

        protected override string PageTitle() => PagesNames.Units;

        protected override string PageUrl() => PagesUrls.Units;
        protected override Unit CreateObj(UnitData d) => new Unit(d);


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _unitsTest = new UnitsTestRepository();
            obj = new UnitsPage(_unitsTest);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("?hikud", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Units", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<UnitView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<UnitView>();
            var view = obj.ToView(UnitViewFactory.Create(d));
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