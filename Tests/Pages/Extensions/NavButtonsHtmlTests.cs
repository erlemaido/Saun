using System.Collections.Generic;
using Aids.Extensions;
using Aids.Reflection;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Aids;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Abstractions.Extensions;

namespace Tests.Pages.Extensions {

    [TestClass] public class NavButtonsHtmlTests : BaseTests {

        private int _totalPages;
        private int _pageIndex;
        private Args _a;
        private List<object> _l;
        private string _actual;
        private string _title;

        [TestInitialize] public void TestInitialize() {
            type = typeof(NavButtonsHtml);
            _title = GetRandom.String();
            _totalPages = GetRandom.UInt8(5);
            _pageIndex = GetRandom.Int32(1, _totalPages - 3);
            _a = GetRandom.Object<Args>();
            _a.Title = GetRandom.String();
            _a.Handler = GetRandom.String();
            _a.Action = GetRandom.String();
            _actual = null;
            _l = new List<object>();
        }

        [TestCleanup] public void TestCleanup() {
            if (_actual is null) return;
            Assert.IsTrue(_actual.Contains(Href.AddPage(_a?.PageUrl)));
            Assert.IsTrue(_actual.Contains(Href.AddAction(_a?.Action)));
            Assert.IsTrue(_actual.Contains(Href.AddHandler(_a?.Handler)));
            Assert.IsTrue(_actual.Contains(Href.AddItemId(_a?.ItemId)));
            Assert.IsTrue(_actual.Contains(Href.AddFixedFilter(_a?.FixedFilter)));
            Assert.IsTrue(_actual.Contains(Href.AddFixedValue(_a?.FixedValue)));
            Assert.IsTrue(_actual.Contains(Href.AddSearchString(_a?.SearchString)));
            Assert.IsTrue(_actual.Contains(Href.AddSortOrder(_a?.SortOrder)));
            Assert.IsTrue(_actual.Contains(Href.AddPageIndex(_a?.PageIndex)));
            Assert.IsTrue(_actual.Contains(Href.AddClass(_a?.Disabled)));
            Assert.IsTrue(_actual.Contains(Href.AddTitle(_a?.Title)));
            _actual = null;
        }

        [TestMethod] public void NavButtonsTest() {
            var obj = new HtmlHelperMock<UnitView>().NavButtons(_a, _totalPages);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        // [TestMethod] public void HtmlStringsTest() {
        //     var expected = new List<string> {
        //         "<a href=\"", "&nbsp;", "<a href=\"", "&nbsp;", "Page ", "&nbsp;", "<a href=\"", "&nbsp;", "<a href=\""
        //     };
        //     var result = NavButtonsHtml.HtmlStrings(_a, _totalPages);
        //     TestHtml.Strings(result, expected);
        // }

        [TestMethod] public void AddLastTest() {
            NavButtonsHtml.AddLast(_l, _a, _pageIndex, _totalPages);
            _actual = _l[0].ToString();
            Assert.AreEqual("Viimane", _a.Title);
            Assert.AreEqual("Index", _a.Handler);
            Assert.AreEqual(null, _a.ItemId);
            Assert.AreEqual(_totalPages, _a.PageIndex);
        }

        [TestMethod] public void HasNextTest() {
            static void Test(int? x, int? y, string s = "") {
                Assert.AreEqual(s, NavButtonsHtml.HasNext(x, y));
            }

            Test(null, null);
            Test(_totalPages, null);
            Test(null, _totalPages);
            Test(_totalPages, _totalPages, "disabled");
            Test(_totalPages - 1, _totalPages);
            Test(_totalPages + 1, _totalPages, "disabled");
        }

        [TestMethod] public void AddNextTest() {
            NavButtonsHtml.AddNext(_l, _a, _pageIndex, _totalPages);
            _actual = _l[0].ToString();
            Assert.AreEqual("Järgmine", _a.Title);
            Assert.AreEqual("Index", _a.Handler);
            Assert.AreEqual(null, _a.ItemId);
            Assert.AreEqual(_pageIndex + 1, _a.PageIndex);
        }

        [TestMethod] public void AddPreviousTest() {
            NavButtonsHtml.AddPrevious(_l, _a, _pageIndex);
            _actual = _l[0].ToString();
            Assert.AreEqual("Eelmine", _a.Title);
            Assert.AreEqual("Index", _a.Handler);
            Assert.AreEqual(null, _a.ItemId);
            Assert.AreEqual(_pageIndex - 1, _a.PageIndex);
        }

        [TestMethod] public void HasPreviousTest() {
            static void Test(int? x, string s = "") => Assert.AreEqual(s, NavButtonsHtml.HasPrevious(x));
 
            Test(null);
            Test(_totalPages);
            Test(1, "disabled");
            Test(0, "disabled");
            Test(-1, "disabled");
        }

        [TestMethod] public void AddFirstTest() {
            NavButtonsHtml.AddFirst(_l, _a, _pageIndex);
            _actual = _l[0].ToString();
            Assert.AreEqual("Esimene", _a.Title);
            Assert.AreEqual("Index", _a.Handler);
            Assert.AreEqual(null, _a.ItemId);
            Assert.AreEqual(1, _a.PageIndex);
        }

        [TestMethod] public void AddPagesInfoTest() {
            NavButtonsHtml.AddPagesInfo(_l, _pageIndex, _totalPages);
            var s = $"<a id=\"pagesInfo\">{Messages.PagesOf.Format(_pageIndex, _totalPages)}</a>";
            Assert.AreEqual(s, _l[0].ToString());
        }

        [TestMethod] public void AddSeparatorTest() {
            NavButtonsHtml.AddSeparator(_l);
            Assert.AreEqual("&nbsp;", _l[0].ToString());
        }

        [TestMethod] public void HtmlButtonTest() {
            var s = GetRandom.String();
            _actual = NavButtonsHtml.HtmlButton(_a, _title, s).ToString();
            Assert.AreEqual(_title, _a.Title);
            Assert.AreEqual("Index", _a.Handler);
            Assert.AreEqual(null, _a.ItemId);
            Assert.AreEqual(s, _a.Disabled);
        }

    }

}
