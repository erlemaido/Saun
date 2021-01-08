using Aids.Reflection;
using Data.Shop.Units;
using Domain.Shop.Units;
using Facade.Shop.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Units;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Units
{
    [TestClass]
    public class UnitsPageTests : SealedViewPageTests<UnitsPage,
            IUnitsRepository, Unit, UnitView, UnitData>
    {
        internal class UnitsRepository : UniqueRepository<Unit, UnitData>, IUnitsRepository
        {
            protected override string GetId(UnitData d) => d.Id;

        }

        private UnitsRepository _units;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Units = new UnitsRepository();
            obj = new UnitsPage(Units);
        }


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Ühikud", obj.PageTitle);

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

        protected override Unit CreateObj(UnitData d)
        {
            throw new System.NotImplementedException();
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

    }

}