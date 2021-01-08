using System;
using System.Collections.Generic;
using Aids.Reflection;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Aids;
using Sauna.Pages.Abstractions.Extensions;

namespace Tests.Pages.Extensions {

    [TestClass] public class DropMenuHtmlTests : BaseTests {

        private string _name;
        private Link[] _items;

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(DropMenuHtml);
            _name = GetRandom.String();
            _items = new[] {
                new Link("A", new Uri("A.A", UriKind.Relative)),
                new Link("B",new Uri("B.B", UriKind.Relative))
            };
        }

        [TestMethod] public void DropMenuTest() {
            var obj = new HtmlHelperMock<UnitView>().DropMenu(_name, _items);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void HtmlStringsTest() {
            var expected = new List<string> {
                "<li class=\"nav-item dropdown\">",
                "<a class=\"nav-link text-dark dropdown-toggle\" href=\"#\" id=\"navbardrop\" data-toggle=\"dropdown\">",
                _name,
                "</a>",
                "<div class=\"dropdown-menu\">",
                "<a class='dropdown-item text-dark' href=\"A.A\">A</a>",
                "<a class='dropdown-item text-dark' href=\"B.B\">B</a>",
                "</div>",
                "</li>"
            };
            var actual = DropMenuHtml.HtmlStrings(_name, _items);
            TestHtml.Strings(actual, expected);
        }

    }

}