using Aids.Reflection;
using Data.Abstractions;
using Domain.Abstractions;
using Facade.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions;

namespace Tests.Pages.Abstractions {


    [TestClass]
    public abstract class SealedPageTests<TClass, TBaseClass, TRepository, TObj, TView, TData>
        : BaseSealedTests<TClass, TBaseClass>
        where TClass : ViewPage<TRepository, TObj, TView, TData>
        where TRepository : class, ICrudMethods<TObj>, ISorting, IFiltering, IPaging
        where TObj : UniqueEntity<TData>
        where TData : UniqueEntityData, new()
        where TView : UniqueEntityView {

        protected string sortOrder;
        protected string searchString;
        protected byte pageIndex;
        protected string fixedFilter;
        protected string fixedValue;
        protected byte createSwitch;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            sortOrder = GetRandom.String();
            searchString = GetRandom.String();
            pageIndex = GetRandom.UInt8();
            fixedFilter = GetRandom.String();
            fixedValue = GetRandom.String();
            createSwitch = GetRandom.UInt8(0, 10);
        }

        [TestMethod] public void ItemIdTest() {
            var item = GetRandom.Object<TView>();
            obj.Item = item;
            Assert.AreEqual(GetId(item), obj.ItemId);
        }

        protected abstract string GetId(TView item);

        [TestMethod] public void PageTitleTest() => Assert.AreEqual(PageTitle(), obj.PageTitle);

        protected abstract string PageTitle();

        [TestMethod] public void PageUrlTest() => Assert.AreEqual(PageUrl(), obj.PageUrl.ToString());

        protected abstract string PageUrl();

        [TestMethod] public virtual void ToObjectTest() {
            var view = GetRandom.Object<TView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod] public virtual void ToViewTest() {
            var d = GetRandom.Object<TData>();
            var view = obj.ToView(CreateObj(d));
            TestArePropertyValuesEqual(view, d);
        }

        protected abstract TObj CreateObj(TData d);

        protected void TestPageProperties(string selId = null, int? pageIdx = null) {
            Assert.AreEqual(selId, obj.SelectedId);
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            Assert.AreEqual(searchString, obj.SearchString);
            Assert.AreEqual(pageIdx ?? pageIndex, obj.PageIndex);
            Assert.AreEqual(sortOrder, obj.SortOrder);
        }

    }

}