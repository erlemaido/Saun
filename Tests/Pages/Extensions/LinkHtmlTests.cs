using System;
using System.Collections.Generic;
using Aids.Reflection;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Aids;
using Sauna.Pages.Abstractions.Extensions;

namespace Tests.Pages.Extensions {

    [TestClass] public class LinkHtmlTests : BaseTests {

        [TestInitialize] public virtual void TestInitialize() => type = typeof(LinkHtml);

        [TestMethod] public void LinkTest() {
            var s = GetRandom.String();
            var items = new[] {new Link("AA", new Uri("AAA", UriKind.Relative)), new Link("BB", new Uri("BBB", UriKind.Relative)) };
            var obj = new HtmlHelperMock<UnitView>().Link(s, items);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void HtmlStringsTest() {
            var s = GetRandom.String();
            var items = new[] {new Link("AA", new Uri("AAA", UriKind.Relative)), new Link("BB", new Uri("BBB", UriKind.Relative)) };
            var expected = new List<string> {
                "<p>", $"<a>{s}</a>", "<a> </a><a href=\"AAA\">AA</a>",
                "<a> </a><a href=\"BBB\">BB</a>", "</p>"
            };
            var actual = LinkHtml.HtmlStrings(s, items);
            TestHtml.Strings(actual, expected);
        }

    }

}