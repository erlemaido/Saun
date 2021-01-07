using System.Collections.Generic;
using Facade.Shop.OrderStatuses;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Extensions;

namespace Tests.Pages.Extensions {

    [TestClass] public class ShowHtmlTests : BaseTests {

        [TestInitialize] public virtual void TestInitialize() => type = typeof(ShowHtml);

        [TestMethod] public void ShowTest() {
            var obj = new HtmlHelperMock<UnitView>().Show(x => x.Code);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void HtmlStringsTest() {
            var expected = new List<string> {"<dt", "DisplayNameFor", "</dt>", "<dd", "DisplayFor", "</dd>"};
            var actual =
                ShowHtml.HtmlStrings(new HtmlHelperMock<OrderStatusView>(), x => x.Time);
            TestHtml.Strings(actual, expected);
        }

    }

}