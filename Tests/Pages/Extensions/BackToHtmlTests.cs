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

        private string _str;
        private Args _a;

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(BackToHtml);
            _str = GetRandom.String();
            _a = GetRandom.Object<Args>();
            _a.Title = GetRandom.String();
            _a.Handler = GetRandom.String();
            _a.ControlId = GetRandom.String();
        }

        [TestMethod] public void BackToTest() {
            var obj = new HtmlHelperMock<UnitView>().BackTo(_a);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void HtmlStringsTest() {
            var actual = BackToHtml.HtmlStrings(_a);
            var s = actual[0].ToString();
            Assert.IsNotNull(s);
            Assert.AreEqual("backToList", _a.ControlId);
            var x = $"<a id=\"{_a.ControlId}\" href=\"{_a.PageUrl}";
            Assert.IsTrue(s.Contains(x));
            Assert.IsTrue(s.Contains($"?handler={_a.Handler}"));
            Assert.IsTrue(s.Contains($"&fixedValue={_a.FixedValue}"));
            Assert.IsTrue(s.Contains($"&fixedFilter={_a.FixedFilter}"));
            Assert.IsTrue(s.Contains($"&sortOrder={_a.SortOrder}"));
            Assert.IsTrue(s.Contains($"&searchString={_a.SearchString}"));
            Assert.IsTrue(s.Contains($"&pageIndex={_a.PageIndex}"));
            Assert.IsTrue(s.Contains($"\">{_a.Title}</a>"));
        }

        [TestMethod] public void GetTitleTest() {
            Assert.AreEqual(Captions.BackToList, BackToHtml.GetTitle(null));
            Assert.AreEqual(_str, BackToHtml.GetTitle(_str));
        }

        [TestMethod] public void GetHandlerTest() {
            Assert.AreEqual(Actions.Index, BackToHtml.GetHandler(null));
            Assert.AreEqual(_str, BackToHtml.GetHandler(_str));
        }

        [TestMethod] public void GetPageUrlTest() {
            Assert.AreEqual(Actions.Index, BackToHtml.GetPageUrl(null).ToString());
            Assert.AreEqual(_str, BackToHtml.GetPageUrl(new Uri(_str, UriKind.Relative)).ToString());
        }

    }

}
