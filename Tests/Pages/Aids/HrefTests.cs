using System;
using Aids.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Aids;

namespace Tests.Pages.Aids {

    [TestClass] public class HrefTests : BaseTests {

        private string _s;
        private int _i;

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(Href);
            _s = GetRandom.String();
            _i = GetRandom.UInt8(5);
        }

        [TestMethod] public void HandlerTest() {
            var a = GetRandom.Object<Args>();
            var handler = GetRandom.String();
            var title = GetRandom.String();
            var actual = Href.Compose(a, handler, title);
            Assert.IsTrue(actual.Contains(Href.AddPage(a?.PageUrl)));
            Assert.IsTrue(actual.Contains(Href.AddAction(handler)));
            Assert.IsTrue(actual.Contains(Href.AddHandler(handler)));
            Assert.IsTrue(actual.Contains(Href.AddItemId(a?.ItemId)));
            Assert.IsTrue(actual.Contains(Href.AddFixedFilter(a?.FixedFilter)));
            Assert.IsTrue(actual.Contains(Href.AddFixedValue(a?.FixedValue)));
            Assert.IsTrue(actual.Contains(Href.AddSearchString(a?.SearchString)));
            Assert.IsTrue(actual.Contains(Href.AddSortOrder(a?.SortOrder)));
            Assert.IsTrue(actual.Contains(Href.AddPageIndex(a?.PageIndex)));
            Assert.IsTrue(actual.Contains(Href.AddTitle(title)));
        }

        [TestMethod] public void ComposeTest() {
            Assert.AreEqual("<a href=\"#\"></a>", Href.Compose(null));
            var a = new Args();
            Assert.AreEqual("<a href=\"#\"></a>", Href.Compose(a));
            a = GetRandom.Object<Args>();
            var actual = Href.Compose(a);
            Assert.IsTrue(actual.Contains(Href.AddPage(a?.PageUrl)));
            Assert.IsTrue(actual.Contains(Href.AddAction(a?.Action)));
            Assert.IsTrue(actual.Contains(Href.AddHandler(a?.Handler)));
            Assert.IsTrue(actual.Contains(Href.AddItemId(a?.ItemId)));
            Assert.IsTrue(actual.Contains(Href.AddFixedFilter(a?.FixedFilter)));
            Assert.IsTrue(actual.Contains(Href.AddFixedValue(a?.FixedValue)));
            Assert.IsTrue(actual.Contains(Href.AddSearchString(a?.SearchString)));
            Assert.IsTrue(actual.Contains(Href.AddSortOrder(a?.SortOrder)));
            Assert.IsTrue(actual.Contains(Href.AddPageIndex(a?.PageIndex)));
            Assert.IsTrue(actual.Contains(Href.AddTitle(a?.Title)));
        }

        [TestMethod] public void AddPageTest() {
            var actual = Href.AddPage(new Uri(_s, UriKind.Relative));
            Assert.AreEqual($"<a href=\"{_s}", actual);
            Assert.AreEqual("<a href=\"#", Href.AddPage(null));
        }

        [TestMethod] public void AddActionTest() {
            var actual = Href.AddAction(_s);
            Assert.AreEqual($"/{_s}?", actual);
            Assert.AreEqual("?", Href.AddAction(null));
        }

        [TestMethod] public void AddHandlerTest() {
            var actual = Href.AddHandler(_s);
            Assert.AreEqual($"handler={_s}", actual);
            Assert.AreEqual(string.Empty, Href.AddHandler(null));
        }

        [TestMethod] public void AddItemIdTest() {
            var actual = Href.AddItemId(_s);
            Assert.AreEqual($"&id={_s}", actual);
            Assert.AreEqual(string.Empty, Href.AddItemId(null));
        }

        [TestMethod] public void AddFixedFilterTest() {
            var actual = Href.AddFixedFilter(_s);
            Assert.AreEqual($"&fixedFilter={_s}", actual);
            Assert.AreEqual(string.Empty, Href.AddFixedFilter(null));
        }

        [TestMethod] public void AddFixedValueTest() {
            var actual = Href.AddFixedValue(_s);
            Assert.AreEqual($"&fixedValue={_s}", actual);
            Assert.AreEqual(string.Empty, Href.AddFixedValue(null));
        }

        [TestMethod] public void AddSortOrderTest() {
            var actual = Href.AddSortOrder(_s);
            Assert.AreEqual($"&sortOrder={_s}", actual);
            Assert.AreEqual(string.Empty, Href.AddSortOrder(null));
        }

        [TestMethod] public void AddSearchStringTest() {
            var actual = Href.AddSearchString(_s);
            Assert.AreEqual($"&searchString={_s}", actual);
            Assert.AreEqual(string.Empty, Href.AddSearchString(null));
        }

        [TestMethod] public void AddPageIndexTest() {
            var actual = Href.AddPageIndex(_i);
            Assert.AreEqual($"&pageIndex={_i}", actual);
            Assert.AreEqual(string.Empty, Href.AddPageIndex(null));
        }

        [TestMethod] public void AddTitleTest() {
            var actual = Href.AddTitle(_s);
            Assert.AreEqual($"\">{_s}</a>", actual);
            Assert.AreEqual("\"></a>", Href.AddTitle(null));
        }

        [TestMethod] public void RemoveTest() {
            Assert.AreEqual(null, Href.Remove(null));
            Assert.AreEqual(string.Empty, Href.Remove(string.Empty));
            Assert.AreEqual(string.Empty, Href.Remove(string.Empty));
            Assert.AreEqual("", Href.Remove("?"));
            Assert.AreEqual("?", Href.Remove("??"));
            Assert.AreEqual(_s, Href.Remove(_s));
            Assert.AreEqual(_s, Href.Remove(_s+"?"));
        }

    }

}
