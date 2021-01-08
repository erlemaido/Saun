using System.Collections.Generic;
using Facade.Shop.OrderStatuses;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Extensions;

namespace Tests.Pages.Extensions
{

    [TestClass]
    public class EditorHtmlTests : BaseTests
    {

        [TestInitialize] public virtual void TestInitialize() => type = typeof(EditorHtml);

        [TestMethod] public void EditorTest() {
            var obj = new HtmlHelperMock<UnitView>().Editor(x => x.Code);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest() {
            var expected = new List<string> { "<div", "LabelFor", "EditorFor", "ValidationMessageFor", "</div>"};
            var actual = EditorHtml.HtmlStrings(new HtmlHelperMock<OrderStatusView>(), x=>x.Time);
            TestHtml.Strings(actual, expected);
        }

    }

}