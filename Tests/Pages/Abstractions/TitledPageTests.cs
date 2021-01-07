using Aids.Reflection;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Facade.Shop.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions;

namespace Tests.Pages.Abstractions {

    [TestClass] public class TitledPageTests
        : AbstractPageTests<TitledPage<IOrdersRepository, Order, OrderView, OrderData>
            , PagedPage<IOrdersRepository, Order, OrderView, OrderData>> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new TestClass(new TestRepository());
        }

        [TestMethod] public void ItemIdTest() {
            obj.Item = GetRandom.Object<OrderView>();
            Assert.AreEqual(obj.Item.Id, obj.ItemId);
        }

        [TestMethod] public void PageTitleTest() {
            IsReadOnlyProperty(obj, nameof(obj.PageTitle), obj.PageTitle);
        }

        [TestMethod] public void PageSubtitleTest() {
            IsReadOnlyProperty(obj, nameof(obj.PageSubtitle), obj.GetPageSubtitle());
        }

        [TestMethod] public void GetPageSubtitleTest() {
            Assert.AreEqual(obj.PageSubtitle, obj.GetPageSubtitle());
        }

        [TestMethod] public void PageUrlTest() {
            IsReadOnlyProperty(obj, nameof(obj.PageUrl), obj.CreatePageUrl());
        }

        [TestMethod] public void GetPageUrlTest() {
            Assert.AreEqual(obj.PageUrl, obj.CreatePageUrl());
        }

        [TestMethod] public void IndexUrlTest() {
            IsReadOnlyProperty(obj.CreateIndexUrl());
        }

        [TestMethod] public void CreationUrlTest() {
            IsReadOnlyProperty(obj.CreateCreationUrl());
        }


        [TestMethod] public void GetIndexUrlTest() {
            Assert.AreEqual(obj.IndexUrl, obj.CreateIndexUrl());
        }

        [TestMethod] public void IsMasterDetailTest() {
            Assert.IsFalse(obj.IsMasterDetail());
            ((TestClass) obj).SubTitle = GetRandom.String();
            obj.FixedValue = GetRandom.String();
            Assert.IsTrue(obj.IsMasterDetail());
        }

    }

}
