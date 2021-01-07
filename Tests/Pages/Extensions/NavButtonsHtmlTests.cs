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

        private int totalPages;
        private int pageIndex;
        private Args a;
        private List<object> l;
        private string actual;
        private string title;

        [TestInitialize] public void TestInitialize() {
            type = typeof(NavButtonsHtml);
            title = GetRandom.String();
            totalPages = GetRandom.UInt8(5);
            pageIndex = GetRandom.Int32(1, totalPages - 3);
            a = GetRandom.Object<Args>();
            a.Title = GetRandom.String();
            a.Handler = GetRandom.String();
            a.Action = GetRandom.String();
            actual = null;
            l = new List<object>();
        }

        [TestCleanup] public void TestCleanup() {
            if (actual is null) return;
            Assert.IsTrue(actual.Contains(Href.AddPage(a?.PageUrl)));
            Assert.IsTrue(actual.Contains(Href.AddAction(a?.Action)));
            Assert.IsTrue(actual.Contains(Href.AddHandler(a?.Handler)));
            Assert.IsTrue(actual.Contains(Href.AddItemId(a?.ItemId)));
            Assert.IsTrue(actual.Contains(Href.AddFixedFilter(a?.FixedFilter)));
            Assert.IsTrue(actual.Contains(Href.AddFixedValue(a?.FixedValue)));
            Assert.IsTrue(actual.Contains(Href.AddSearchString(a?.SearchString)));
            Assert.IsTrue(actual.Contains(Href.AddSortOrder(a?.SortOrder)));
            Assert.IsTrue(actual.Contains(Href.AddPageIndex(a?.PageIndex)));
            Assert.IsTrue(actual.Contains(Href.AddClass(a?.Disabled)));
            Assert.IsTrue(actual.Contains(Href.AddTitle(a?.Title)));
            actual = null;
        }

        [TestMethod] public void NavButtonsTest() {
            var obj = new HtmlHelperMock<UnitView>().NavButtons(a, totalPages);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void HtmlStringsTest() {
            var expected = new List<string> {
                "<a href=\"", "&nbsp;", "<a href=\"", "&nbsp;", "Page ", "&nbsp;", "<a href=\"", "&nbsp;", "<a href=\""
            };
            var result = NavButtonsHtml.HtmlStrings(a, totalPages);
            TestHtml.Strings(result, expected);
        }

        [TestMethod] public void AddLastTest() {
            NavButtonsHtml.AddLast(l, a, pageIndex, totalPages);
            actual = l[0].ToString();
            Assert.AreEqual("Viimane", a.Title);
            Assert.AreEqual("Index", a.Handler);
            Assert.AreEqual(null, a.ItemId);
            Assert.AreEqual(totalPages, a.PageIndex);
        }

        [TestMethod] public void HasNextTest() {
            static void test(int? x, int? y, string s = "") {
                Assert.AreEqual(s, NavButtonsHtml.HasNext(x, y));
            }

            test(null, null);
            test(totalPages, null);
            test(null, totalPages);
            test(totalPages, totalPages, "disabled");
            test(totalPages - 1, totalPages);
            test(totalPages + 1, totalPages, "disabled");
        }

        [TestMethod] public void AddNextTest() {
            NavButtonsHtml.AddNext(l, a, pageIndex, totalPages);
            actual = l[0].ToString();
            Assert.AreEqual("Järgmine", a.Title);
            Assert.AreEqual("Index", a.Handler);
            Assert.AreEqual(null, a.ItemId);
            Assert.AreEqual(pageIndex + 1, a.PageIndex);
        }

        [TestMethod] public void AddPreviousTest() {
            NavButtonsHtml.AddPrevious(l, a, pageIndex);
            actual = l[0].ToString();
            Assert.AreEqual("Eelmine", a.Title);
            Assert.AreEqual("Index", a.Handler);
            Assert.AreEqual(null, a.ItemId);
            Assert.AreEqual(pageIndex - 1, a.PageIndex);
        }

        [TestMethod] public void HasPreviousTest() {
            static void test(int? x, string s = "") => Assert.AreEqual(s, NavButtonsHtml.HasPrevious(x));
 
            test(null);
            test(totalPages);
            test(1, "disabled");
            test(0, "disabled");
            test(-1, "disabled");
        }

        [TestMethod] public void AddFirstTest() {
            NavButtonsHtml.AddFirst(l, a, pageIndex);
            actual = l[0].ToString();
            Assert.AreEqual("Esimene", a.Title);
            Assert.AreEqual("Index", a.Handler);
            Assert.AreEqual(null, a.ItemId);
            Assert.AreEqual(1, a.PageIndex);
        }

        [TestMethod] public void AddPagesInfoTest() {
            NavButtonsHtml.AddPagesInfo(l, pageIndex, totalPages);
            var s = $"<a id=\"pagesInfo\">{Messages.PagesOf.Format(pageIndex, totalPages)}</a>";
            Assert.AreEqual(s, l[0].ToString());
        }

        [TestMethod] public void AddSeparatorTest() {
            NavButtonsHtml.AddSeparator(l);
            Assert.AreEqual("&nbsp;", l[0].ToString());
        }

        [TestMethod] public void HtmlButtonTest() {
            var s = GetRandom.String();
            actual = NavButtonsHtml.HtmlButton(a, title, s).ToString();
            Assert.AreEqual(title, a.Title);
            Assert.AreEqual("Index", a.Handler);
            Assert.AreEqual(null, a.ItemId);
            Assert.AreEqual(s, a.Disabled);
        }

    }

}
