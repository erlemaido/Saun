using System;
using Aids.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Aids;

namespace Tests.Pages.Aids {

    [TestClass] public class ArgsTests : BaseSealedTests<Args, object> {

        private Uri pageUrl;
        private string itemId;
        private string fixedFilter;
        private string fixedValue;
        private string sortOrder;
        private string searchString;
        private string currentFilter;
        private int? pageIndex;
        private string handler;
        private string title;
        private string action;
        private string disabled;
        private string controlId;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            pageIndex = GetRandom.UInt8();
            pageUrl = new Uri(GetRandom.String(), UriKind.Relative);
            itemId = GetRandom.String();
            fixedFilter = GetRandom.String();
            fixedValue = GetRandom.String();
            sortOrder = GetRandom.String();
            searchString = GetRandom.String();
            currentFilter = GetRandom.String();
            action = GetRandom.String();
            disabled = GetRandom.String();
            controlId = GetRandom.String();
            obj = new Args(pageUrl, itemId, fixedFilter, fixedValue, sortOrder, searchString, pageIndex, currentFilter);
            handler = GetRandom.String();
            title = GetRandom.String();
            obj.Handler = handler;
            obj.Title = title;
            obj.Action = action;
            obj.Disabled = disabled;
            obj.ControlId = controlId;
        }

        [TestMethod] public void PageUrlTest() => Assert.AreEqual(pageUrl, obj.PageUrl);

        [TestMethod] public void PageIndexTest() => Assert.AreEqual(pageIndex, obj.PageIndex);

        [TestMethod] public void ItemIdTest() => Assert.AreEqual(itemId, obj.ItemId);

        [TestMethod] public void FixedFilterTest() => Assert.AreEqual(fixedFilter, obj.FixedFilter);

        [TestMethod] public void FixedValueTest() => Assert.AreEqual(fixedValue, obj.FixedValue);

        [TestMethod] public void SortOrderTest() => Assert.AreEqual(sortOrder, obj.SortOrder);

        [TestMethod] public void SearchStringTest() => Assert.AreEqual(searchString, obj.SearchString);
        [TestMethod] public void CurrentFilterTest() => Assert.AreEqual(currentFilter, obj. CurrentFilter);

        [TestMethod] public void HandlerTest() => Assert.AreEqual(handler, obj.Handler);

        [TestMethod] public void TitleTest() => Assert.AreEqual(title, obj.Title);
        [TestMethod] public void ActionTest() => Assert.AreEqual(action, obj.Action);
        [TestMethod] public void DisabledTest() => Assert.AreEqual(disabled, obj.Disabled);
        [TestMethod] public void ControlIdTest() => Assert.AreEqual(controlId, obj.ControlId);

        [TestMethod] public void RowArgsTest() {
            Assert.IsNotNull(new Args());
        }

        [TestMethod] public void CreateRowArgsTest() {
            var a = new Args(pageUrl, itemId, fixedFilter,
                fixedValue, sortOrder, searchString, pageIndex);
            Assert.AreEqual(pageUrl, a.PageUrl);
            Assert.AreEqual(itemId, a.ItemId);
            Assert.AreEqual(fixedFilter, a.FixedFilter);
            Assert.AreEqual(fixedValue, a.FixedValue);
            Assert.AreEqual(sortOrder, a.SortOrder);
            Assert.AreEqual(searchString, a.SearchString);
            Assert.AreEqual(pageIndex, a.PageIndex);
            Assert.AreEqual(null, a.Handler);
            Assert.AreEqual(null, a.Title);
        }

    }

}
