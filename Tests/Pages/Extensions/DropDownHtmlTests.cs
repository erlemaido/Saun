using System.Collections.Generic;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Extensions;

namespace Tests.Pages.Extensions {

    [TestClass] public class DropDownHtmlTests : BaseTests {

        private readonly List<SelectListItem> _items = new List<SelectListItem> {new SelectListItem("text", "value")};

        [TestInitialize] public virtual void TestInitialize() => type = typeof(DropDownHtml);

        [TestMethod] public void DropDownTest() {
            var obj = new HtmlHelperMock<UnitView>().DropDown(x => x.Code, _items);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void HtmlStringsTest() {
            var expected = new List<string> {"<div", "LabelFor", "DropDownListFor", "ValidationMessageFor", "</div>"};
            var actual = DropDownHtml.HtmlStrings(new HtmlHelperMock<UnitView>(),
                x => x.Code, _items);
            TestHtml.Strings(actual, expected);
        }

    }

}
