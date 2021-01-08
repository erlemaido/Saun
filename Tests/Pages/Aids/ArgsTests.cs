using System;
using Aids.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Aids;

namespace Tests.Pages.Aids {

    [TestClass] public class ArgsTests : BaseSealedTests<Args, object> {

        private Uri _pageUrl;
        private string _itemId;
        private string _fixedFilter;
        private string _fixedValue;
        private string _sortOrder;
        private string _searchString;
        private string _currentFilter;
        private int? _pageIndex;
        private string _handler;
        private string _title;
        private string _action;
        private string _disabled;
        private string _controlId;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            _pageIndex = GetRandom.UInt8();
            _pageUrl = new Uri(GetRandom.String(), UriKind.Relative);
            _itemId = GetRandom.String();
            _fixedFilter = GetRandom.String();
            _fixedValue = GetRandom.String();
            _sortOrder = GetRandom.String();
            _searchString = GetRandom.String();
            _currentFilter = GetRandom.String();
            _action = GetRandom.String();
            _disabled = GetRandom.String();
            _controlId = GetRandom.String();
            obj = new Args(_pageUrl, _itemId, _fixedFilter, _fixedValue, _sortOrder, _searchString, _pageIndex, _currentFilter);
            _handler = GetRandom.String();
            _title = GetRandom.String();
            obj.Handler = _handler;
            obj.Title = _title;
            obj.Action = _action;
            obj.Disabled = _disabled;
            obj.ControlId = _controlId;
        }

        [TestMethod] public void PageUrlTest() => Assert.AreEqual(_pageUrl, obj.PageUrl);

        [TestMethod] public void PageIndexTest() => Assert.AreEqual(_pageIndex, obj.PageIndex);

        [TestMethod] public void ItemIdTest() => Assert.AreEqual(_itemId, obj.ItemId);

        [TestMethod] public void FixedFilterTest() => Assert.AreEqual(_fixedFilter, obj.FixedFilter);

        [TestMethod] public void FixedValueTest() => Assert.AreEqual(_fixedValue, obj.FixedValue);

        [TestMethod] public void SortOrderTest() => Assert.AreEqual(_sortOrder, obj.SortOrder);

        [TestMethod] public void SearchStringTest() => Assert.AreEqual(_searchString, obj.SearchString);
        [TestMethod] public void CurrentFilterTest() => Assert.AreEqual(_currentFilter, obj. CurrentFilter);

        [TestMethod] public void HandlerTest() => Assert.AreEqual(_handler, obj.Handler);

        [TestMethod] public void TitleTest() => Assert.AreEqual(_title, obj.Title);
        [TestMethod] public void ActionTest() => Assert.AreEqual(_action, obj.Action);
        [TestMethod] public void DisabledTest() => Assert.AreEqual(_disabled, obj.Disabled);
        [TestMethod] public void ControlIdTest() => Assert.AreEqual(_controlId, obj.ControlId);

        [TestMethod] public void RowArgsTest() {
            Assert.IsNotNull(new Args());
        }

        [TestMethod] public void CreateRowArgsTest() {
            var a = new Args(_pageUrl, _itemId, _fixedFilter,
                _fixedValue, _sortOrder, _searchString, _pageIndex);
            Assert.AreEqual(_pageUrl, a.PageUrl);
            Assert.AreEqual(_itemId, a.ItemId);
            Assert.AreEqual(_fixedFilter, a.FixedFilter);
            Assert.AreEqual(_fixedValue, a.FixedValue);
            Assert.AreEqual(_sortOrder, a.SortOrder);
            Assert.AreEqual(_searchString, a.SearchString);
            Assert.AreEqual(_pageIndex, a.PageIndex);
            Assert.AreEqual(null, a.Handler);
            Assert.AreEqual(null, a.Title);
        }

    }

}
