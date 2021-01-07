using Aids.Reflection;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Facade.Shop.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions;

namespace Tests.Pages.Abstractions {

    [TestClass]
    public class CrudPageTests : AbstractPageTests<CrudPage<IOrdersRepository, Order, OrderView, OrderData>,
        BasePage<IOrdersRepository, Order, OrderView, OrderData>> {

        private string _fixedFilter;
        private string _fixedValue;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new TestClass(db);
            _fixedFilter = GetRandom.String();
            _fixedValue = GetRandom.String();
            Assert.AreEqual(null, obj.FixedValue);
            Assert.AreEqual(null, obj.FixedFilter);
        }

        [TestMethod] public void ItemTest() {
            IsProperty(() => obj.Item, x => obj.Item = x);
        }

        [TestMethod] public void AddObjectTest() {
            var idx = db.list.Count;
            obj.Item = GetRandom.Object<OrderView>();
            obj.AddObject(_fixedFilter, _fixedValue).GetAwaiter();
            Assert.AreEqual(_fixedFilter, obj.FixedFilter);
            Assert.AreEqual(_fixedValue, obj.FixedValue);
            TestArePropertyValuesEqual(obj.Item, db.list[idx].Data);
        }

        [TestMethod] public void UpdateObjectTest() {
            GetObjectTest();
            var idx = GetRandom.Int32(0, db.list.Count);
            var itemId = db.list[idx].Data.Id;
            obj.Item = GetRandom.Object<OrderView>();
            obj.Item.Id = itemId;
            obj.UpdateObject(_fixedFilter, _fixedValue).GetAwaiter();
            TestArePropertyValuesEqual(db.list[^1].Data, obj.Item);
        }

        [TestMethod] public void GetObjectTest() {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);
            for (var i = 0; i < count; i++) AddObjectTest();
            var item = db.list[idx];
            obj.GetObject(item.Data.Id, _fixedFilter, _fixedValue).GetAwaiter();
            Assert.AreEqual(count, db.list.Count);
            TestArePropertyValuesEqual(item.Data, obj.Item);
        }

        [TestMethod] public void DeleteObjectTest() {
            AddObjectTest();
            obj.DeleteObject(obj.Item.Id, _fixedFilter, _fixedValue).GetAwaiter();
            Assert.AreEqual(_fixedFilter, obj.FixedFilter);
            Assert.AreEqual(_fixedValue, obj.FixedValue);
            Assert.AreEqual(0, db.list.Count);
        }

        [TestMethod] public void ToViewTest() {
            var d = GetRandom.Object<OrderData>();
            var v = obj.ToView(new Order(d));
            TestArePropertyValuesEqual(d, v);
        }

        [TestMethod] public void ToObjectTest() {
            var v = GetRandom.Object<OrderView>();
            var o = obj.ToObject(v);
            TestArePropertyValuesEqual(v, o.Data);
        }

        [TestMethod] public void ItemIdTest() {
            obj.Item = GetRandom.Object<OrderView>();
            Assert.AreEqual(obj.Item.GetId(),obj.ItemId);
        }
    }

}
