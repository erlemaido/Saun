using System;
using Aids.Reflection;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Aids;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Abstractions.Extensions;

namespace Tests.Pages.Extensions {

    [TestClass] public class BackToHtmlTests : BaseTests {

        private string str;
        private Args a;

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(BackToHtml);
            str = GetRandom.String();
            a = GetRandom.Object<Args>();
            a.Title = GetRandom.String();
            a.Handler = GetRandom.String();
            a.ControlId = GetRandom.String();
        }

        [TestMethod] public void BackToTest() {
            var obj = new HtmlHelperMock<UnitView>().BackTo(a);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void HtmlStringsTest() {
            var actual = BackToHtml.HtmlStrings(a);
            var s = actual[0].ToString();
            Assert.IsNotNull(s);
            Assert.AreEqual("backToList", a.ControlId);
            var x = $"<a id=\"{a.ControlId}\" href=\"{a.PageUrl}";
            Assert.IsTrue(s.Contains(x));
            Assert.IsTrue(s.Contains($"?handler={a.Handler}"));
            Assert.IsTrue(s.Contains($"&fixedValue={a.FixedValue}"));
            Assert.IsTrue(s.Contains($"&fixedFilter={a.FixedFilter}"));
            Assert.IsTrue(s.Contains($"&sortOrder={a.SortOrder}"));
            Assert.IsTrue(s.Contains($"&searchString={a.SearchString}"));
            Assert.IsTrue(s.Contains($"&pageIndex={a.PageIndex}"));
            Assert.IsTrue(s.Contains($"\">{a.Title}</a>"));
        }

        [TestMethod] public void GetTitleTest() {
            Assert.AreEqual(Captions.BackToList, BackToHtml.GetTitle(null));
            Assert.AreEqual(str, BackToHtml.GetTitle(str));
        }

        [TestMethod] public void GetHandlerTest() {
            Assert.AreEqual(Actions.Index, BackToHtml.GetHandler(null));
            Assert.AreEqual(str, BackToHtml.GetHandler(str));
        }

        [TestMethod] public void GetPageUrlTest() {
            Assert.AreEqual(Actions.Index, BackToHtml.GetPageUrl(null).ToString());
            Assert.AreEqual(str, BackToHtml.GetPageUrl(new Uri(str, UriKind.Relative)).ToString());
        }

    }

}
