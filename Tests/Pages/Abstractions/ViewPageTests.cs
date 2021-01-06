using Aids.Reflection;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Facade.Shop.Orders;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions;

namespace Tests.Pages.Abstractions {

    [TestClass] public class ViewPageTests : AbstractPageTests<
        ViewPage<IOrdersRepository, Order, OrderView, OrderData>,
        TitledPage<IOrdersRepository, Order, OrderView, OrderData>> {

        private TestRepository _repository;
        private int _count;
        private string _sortOrder;
        private string _id;
        private string _currentFilter;
        private string _searchString;
        private byte _pageIndex;
        private string _fixedFilter;
        private string _fixedValue;
        private byte _createSwitch;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            _repository = new TestRepository();
            SetRandomValues();
            AddRandomItems();
            obj = new TestClass(_repository);
        }

        private void SetRandomValues() {
            _sortOrder = GetRandom.String();
            _id = GetRandom.String();
            _currentFilter = GetRandom.String();
            _searchString = GetRandom.String();
            _pageIndex = GetRandom.UInt8();
            _fixedFilter = GetRandom.String();
            _fixedValue = GetRandom.String();
            _createSwitch = GetRandom.UInt8(0, 10);
        }

        private void AddRandomItems() {
            _count = GetRandom.UInt8(10, 100);
            for (var i = 0; i < _count; i++)
                _repository.Add(new Order(GetRandom.Object<OrderData>())).GetAwaiter();
        }

        [TestMethod] public void OnGetIndexAsyncTest() {

            Assert.IsNull(obj.Items);
            obj.OnGetIndexAsync(null, null, null, null, null, null, null).GetAwaiter();
            Assert.AreEqual(_count, obj.Items.Count);
        }

        [TestMethod] public void OnGetIndexAsyncArgumentsTest() {

            Assert.IsNull(obj.Items);
            obj.OnGetIndexAsync(_sortOrder, _id, _currentFilter, _searchString, _pageIndex, _fixedFilter, _fixedValue)
                .GetAwaiter();
            Assert.AreEqual(0, obj.Items.Count);
            TestPageProperties(_id, 1);
        }

        [TestMethod] public void OnGetCreateTest() {

            var page = obj.OnGetCreate(_sortOrder, _searchString, _pageIndex, _fixedFilter, _fixedValue, _createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod] public void OnPostCreateAsyncTest() {
            obj.Item = GetRandom.Object<OrderView>();
            var o = _repository.Get(obj.Item.Id).GetAwaiter().GetResult();
            Assert.IsNull(o);
            obj.OnPostCreateAsync(_sortOrder, _searchString, _pageIndex, _fixedFilter, _fixedValue).GetAwaiter();
            o = _repository.Get(obj.Item.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            //Assert.IsFalse(o.IsUnspecified);
            TestArePropertyValuesEqual(obj.Item, o.Data);
            TestPageProperties();
        }

        [TestMethod] public void OnGetDeleteAsyncTest() {
            obj.OnGetDeleteAsync(_id, _sortOrder, _searchString, _pageIndex, _fixedFilter, _fixedValue).GetAwaiter();
            TestArePropertyValuesEqual(new OrderView(), obj.Item);
            var idx = GetRandom.Int32(0, _count);
            var m = _repository.list[idx];
            obj.OnGetDeleteAsync(m.Data.Id, _sortOrder, _searchString, _pageIndex, _fixedFilter, _fixedValue).GetAwaiter();
            TestArePropertyValuesEqual(m.Data, obj.Item);
            TestPageProperties();
        }

        private void TestPageProperties(string selId = null, int? pageIdx = null) {
            Assert.AreEqual(selId, obj.SelectedId);
            Assert.AreEqual(_fixedFilter, obj.FixedFilter);
            Assert.AreEqual(_fixedValue, obj.FixedValue);
            Assert.AreEqual(_searchString, obj.SearchString);
            Assert.AreEqual(pageIdx ?? _pageIndex, obj.PageIndex);
            Assert.AreEqual(_sortOrder, obj.SortOrder);
        }

        [TestMethod] public void OnPostDeleteAsyncTest() {
            var idx = GetRandom.Int32(0, _count);
            var expected = _repository.list[idx];
            var actual = _repository.Get(expected.Data.Id).GetAwaiter().GetResult();
            TestArePropertyValuesEqual(expected.Data, actual.Data);
            obj.OnPostDeleteAsync(expected.Data.Id, _sortOrder, _searchString, _pageIndex, _fixedFilter, _fixedValue)
                .GetAwaiter().GetResult();
            actual = _repository.Get(expected.Data.Id).GetAwaiter().GetResult();
            Assert.IsNull(actual);
            TestPageProperties();
        }

        [TestMethod] public void OnGetDetailsAsyncTest() {
            obj.OnGetDetailsAsync(_id, _sortOrder, _searchString, _pageIndex, _fixedFilter, _fixedValue).GetAwaiter();
            TestArePropertyValuesEqual(new OrderView(), obj.Item);
            var idx = GetRandom.Int32(0, _count);
            var m = _repository.list[idx];
            obj.OnGetDeleteAsync(m.Data.Id, _sortOrder, _searchString, _pageIndex, _fixedFilter, _fixedValue).GetAwaiter();
            TestArePropertyValuesEqual(m.Data, obj.Item);
            TestPageProperties();

        }

        [TestMethod] public void OnGetEditAsyncTest() {
            obj.OnGetEditAsync(_id, _sortOrder, _searchString, _pageIndex, _fixedFilter, _fixedValue).GetAwaiter();
            TestArePropertyValuesEqual(new OrderView(), obj.Item);
            var idx = GetRandom.Int32(0, _count);
            var m = _repository.list[idx];
            obj.OnGetEditAsync(m.Data.Id, _sortOrder, _searchString, _pageIndex, _fixedFilter, _fixedValue).GetAwaiter();
            TestArePropertyValuesEqual(m.Data, obj.Item);
            TestPageProperties();
        }

        [TestMethod] public void OnPostEditAsyncTest() {
            obj.Item = GetRandom.Object<OrderView>();
            var o = _repository.Get(obj.Item.Id).GetAwaiter().GetResult();
            Assert.IsNull(o);
            obj.OnPostEditAsync(_sortOrder, _searchString, _pageIndex, _fixedFilter, _fixedValue).GetAwaiter();
            o = _repository.Get(obj.Item.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            //Assert.IsFalse(o.IsUnspecified);
            TestArePropertyValuesEqual(o.Data, obj.Item);
            TestPageProperties();
        }

    }

}
